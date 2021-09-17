# Day28 - 輕前端 Component - 多個 jQuery UI Selectmenu 連動

這篇套用並調整 Day26 的 jQuery UI Selectmenu Vue Component

來產生三個 jQuery UI Selecemenu 下拉選單的連動 !

---

## Case01

Controller

- 新增取得下拉選單項目 web api

    ```csharp
    [HttpPost, Route("api/[controller]/[action]")]
    [ValidateAntiForgeryToken]
    public IActionResult GetChildOptions([FromBody]int? id)
    {
        var result = _allOptions.Where(o => o.ParentValue == id).ToArray();

        return Ok(result);
    }

    private Option[] _allOptions
        = new Option[]
            {
                new() { Value = 1, Text  = "1", ParentValue     = null },
                new() { Value = 2, Text  = "1-1", ParentValue   = 1 },
                new() { Value = 3, Text  = "1-1-1", ParentValue = 2 },
                new() { Value = 4, Text  = "1-1-2", ParentValue = 2 },
                new() { Value = 5, Text  = "1-1-3", ParentValue = 2 },
                new() { Value = 6, Text  = "1-1-4", ParentValue = 2 },
                new() { Value = 7, Text  = "1-2", ParentValue   = 1 },
                new() { Value = 8, Text  = "1-2-1", ParentValue = 7 },
                new() { Value = 9, Text  = "1-2-2", ParentValue = 7 },
                new() { Value = 10, Text = "1-2-3", ParentValue = 7 },
                new() { Value = 11, Text = "1-2-4", ParentValue = 7 },
                new() { Value = 12, Text = "2", ParentValue     = null },
                new() { Value = 13, Text = "2-1", ParentValue   = 12 },
                new() { Value = 14, Text = "2-1-1", ParentValue = 13 },
                new() { Value = 15, Text = "2-1-2", ParentValue = 13 },
                new() { Value = 16, Text = "2-1-3", ParentValue = 13 },
                new() { Value = 17, Text = "2-1-4", ParentValue = 13 },
                new() { Value = 18, Text = "2-2", ParentValue   = 12 },
                new() { Value = 19, Text = "2-2-1", ParentValue = 18 },
                new() { Value = 20, Text = "2-2-2", ParentValue = 18 },
                new() { Value = 21, Text = "2-2-3", ParentValue = 18 },
                new() { Value = 22, Text = "2-2-4", ParentValue = 18 },
                new() { Value = 23, Text = "3", ParentValue     = null },
                new() { Value = 24, Text = "3-1", ParentValue   = 23 },
                new() { Value = 25, Text = "3-1-1", ParentValue = 24 },
                new() { Value = 26, Text = "3-1-2", ParentValue = 24 },
                new() { Value = 27, Text = "3-1-3", ParentValue = 24 },
                new() { Value = 28, Text = "3-1-4", ParentValue = 24 },
                new() { Value = 29, Text = "3-2", ParentValue   = 23 },
                new() { Value = 30, Text = "3-2-1", ParentValue = 29 },
                new() { Value = 31, Text = "3-2-2", ParentValue = 29 },
                new() { Value = 32, Text = "3-2-3", ParentValue = 29 },
                new() { Value = 33, Text = "3-2-4", ParentValue = 29 },
            };
    ```

調整 jquery-ui-select-menu.js

- 修改的意圖是：
  - 假如有給定 props.options，則以 props.options 做為下拉選單項目清單 !
  - 亦可以透過 function update_options() 來給定下拉選單項目清單 !
    - 透過這個 function 給定 options 時，要呼叫 jQuery UI Selectmenu 重新整理下拉選單項目清單 !

    ```js
    const jquery_ui_select_menu = {
        template: `
            <select v-bind:id="id"
                    v-model="modelValue">
                <option value="null">請選擇</option>
                <option v-for="(item, item_index) in options"
                        v-bind:key="item.Value"
                        v-bind:value="item.Value">
                    {{ item.Text }}
                </option>
            </select>
        `,
        props: {
            id: String,
            options : Array,
            modelValue: Number,
            width: Number,
        },
        setup(props, {emit}) {

            const options = ref(props.options || []);
            let dom = $("#"+ props.id);

            onMounted(() => {
                dom = $("#"+ props.id);
                dom.selectmenu({
                    width: props.width,
                    change: function (event, ui) {
                        emit('update:modelValue', parseInt(ui.item.value));
                        emit('change', parseInt(ui.item.value))
                    }
                });
            })

            const update_options = async function (import_options) {
                options.value =  import_options;

                if(dom.selectmenu( "instance" )) {
                    await nextTick();
                    dom.selectmenu( "refresh" );
                }
            }

            return {
                options,
                update_options,
            }
        },
    }
    ```

View

- 引用上述 component

  原本 vue 指定 mount 的地方上面加上 js script 的引用

  ```html
  </script>
  <script src="/lib/jquery-ui-select-menu.js?20210608001"></script>
  <script>
      app.component("jquery-ui-select-menu", jquery_ui_select_menu);
  
      const vm = app.mount('#app');
  </script>
  ```

- Html

    ```html
    <div id="app"
        v-cloak>
        <form autocomplete="off"
            v-on:submit.prevent="submit_form">
            <div>
                <label>項目1：</label>
                <jquery-ui-select-menu ref="ref_options1"
                                       v-model="vue_model.OptionId1"
                                       v-bind:id="'OptionId1'"
                                       v-bind:width=200
                                       v-on:change="refresh_option2($event);">
                </jquery-ui-select-menu>
            </div>
            <div>
                <label>項目2：</label>
                <jquery-ui-select-menu ref="ref_options2"
                                       v-model="vue_model.OptionId2"
                                       v-bind:id="'OptionId2'"
                                       v-bind:width=200
                                       v-on:change="refresh_option3($event);">
                </jquery-ui-select-menu>
            </div>
            <div>
                <label>項目3：</label>
                <jquery-ui-select-menu ref="ref_options3"
                                       v-model="vue_model.OptionId3"
                                       v-bind:id="'OptionId3'"
                                       v-bind:width=200>
                </jquery-ui-select-menu>
            </div>
            <p>
                <button type="submit">送出</button>
            </p>
        </form>
        <p>
            <a v-bind:href="prev_url">回上一層</a>
        </p>
    </div>
    ```
- vue
  - 透過 template refs 抓出三個下拉選單 component

    ```js
    const ref_options1 = ref(null);
    const ref_options2 = ref(null);
    const ref_options3 = ref(null);
    ```
    
  - 在 mouted 之後，就立即更新 options1 下拉選單內容 ! 

    ```js
    onMounted(() => {
        refresh_option1();
    });
    ```

 - 把取得指定 optionId 下的動作改成回傳的型態

    ```js
    const get_child_options = async function (id) {
        return await CustomFetch.PostJson(get_child_options_url, id);
    };

    const refresh_option1 = async function () {

        vue_model.value.OptionId1 = null;
        const options1 = await get_child_options(null);
        ref_options1.value.update_options(options1);

        refresh_option2(null);
    };

    const refresh_option2 = async function (optionId1) {
        vue_model.value.OptionId2 = null;

        if (optionId1) {
            const options2 = await get_child_options(optionId1);
            ref_options2.value.update_options(options2);
        } else {
            ref_options2.value.update_options(null);
        }

        refresh_option3(null);
    };

    const refresh_option3 = async function (optionId2) {
        vue_model.value.OptionId3 = null;

        if (optionId2) {
            const options3 = await get_child_options(optionId2);
            ref_options3.value.update_options(options3);
        } else {
            ref_options3.value.update_options(null);
        }
    };
    ```

---

這篇先到這裡，下一篇來看看 jQuery UI Dialog !
