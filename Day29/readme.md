# Day29 - 輕前端 Component - jQuery UI Dialog

這個範例實作：在 Dialog 內放入表單，確認 submit 後，才關閉 Dialog。

---

## Case01

Controller

- 與 Day18 一樣，不需要特別調整

建立 jquery-ui-dialog.css

```css
.ui-widget-overlay {
    opacity: .7;
}
```

建立 jquery-ui-dialog.js

  - open() 開啟 dialog
  - close() 關閉 dialog
  - 開啟/關閉 dialog 時，就變更 show_content 值，來控制 Dialog 內容是否顯示

    ```js
    const jquery_ui_dialog = {
        template: `
            <div v-bind:id="id"
                v-bind:title="title">
                <slot name="content"
                    v-if="show_content"></slot>
            </div>
        `,
        props: {
            id : String,
            title : String,
            width : Number,
            height : Number,
        },

        setup(props, { emit }) {

            let dialogDom = null;

            const show_content = ref(false);

            onMounted(() => {

                dialogDom = $( '#' + props.id );
                dialogDom.dialog({
                    autoOpen: false,
                    height: props.height,
                    width: props.width,
                    modal: true
                });
            })

            const open = function() {
                dialogDom.dialog( "open" );
                show_content.value = true;

                $('.ui-widget-overlay').on('click', function()
                {
                    close();
                });
            }

            const close = function() {
                show_content.value = false;
                dialogDom.dialog( "close" );
            }

            return {
                show_content,
                open,
                close,
            }
        },
    }
    ```

View

- 引用上述 component 及 css

  原本 vue 指定 mount 的地方上面加上 js script 的引用

  ```html
  </script>
  <link rel="stylesheet" href="/lib/jquery-ui-dialog.css?20210611001">
  <script src="/lib/jquery-ui-dialog.js?20210611001"></script>
  <script>
      app.component("jquery-ui-dialog", jquery_ui_dialog);
  
      const vm = app.mount('#app');
  </script>
  ```

- Html

    - 按下`開啟 Dialog Button`後，直接呼叫 dialog.open() 來開啟 dialog
    - 在 submit form 時，往後端送資料，如果沒問題，就呼叫 dialog.close() 來關閉 dialog

    ```html
    <div id="app"
        v-cloak>
        <p>
            <button type="button"
                    v-on:click="dialog.open()">開啟 Dialog</button>
        </p>
        <jquery-ui-dialog ref="dialog"
                        v-bind:id="'dialog'"
                        v-bind:title="'表單範例'"
                        v-bind:width="300"
                        v-bind:height="210" >
            <template v-slot:content>
                <form autocomplete="off"
                    v-on:submit.prevent="submit_form">
                    <p>
                        <label>編號：</label>
                        <input type="number"
                            step="1"
                            min="0"
                            v-model="vue_model.Id">
                    </p>
                    <p>
                        <label>姓名：</label>
                        <input type="text"
                            v-model="vue_model.Name">
                    </p>
                    <p>
                        <button type="submit">送出</button>
                    </p>
                </form>
            </template>
        </jquery-ui-dialog>
        <p>
            <a v-bind:href="prev_url">回上一層</a>
        </p>
    </div>
    ```

---

這篇先到這裡，下一篇來看看輕前端綜合版的範例 !
