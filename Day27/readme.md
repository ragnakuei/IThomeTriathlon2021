# Day27 - 輕前端 Component - jQuery UI DatePicker

這篇要做的：把訂單日期改用 jQuery UI DatePicker + vue component !

---

## Case01

建立 jquery-ui-date-picker.js

- 把 jQuery UI DatePicker 放在這個 component 內 !

  ```js
  const jquery_ui_date_picker = {
        template: `
            <input type="text" 
                v-bind:id="id"
                v-model="dom_value" />
        `,
        props: {
            id: String,
            date_format: String,
            modelValue: String,
        },
        setup(props, {emit}) {

            let dom = null;

            onMounted(() => {
                dom = $("#"+ props.id);
                dom.datepicker({
                    dateFormat: props.date_format || "yy-mm-dd",
                    onClose : function (dateText, inst) {
                        dom_value.value = dateText;
                    }
                });
            })

            const dom_value = computed({
                get: () => {
                    return props.modelValue?.split('T')[0];
                },
                set: (v) => {
                    if (v === "")
                    {
                        v = null;
                    }

                    emit('update:modelValue', v);
                },
            });

            return {
                dom_value,
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
  <script src="/lib/jquery-ui-date-picker.js?20210608001"></script>
  <script>
      app.component("jquery-ui-select-menu", jquery_ui_select_menu);
      app.component("jquery-ui-date-picker", jquery_ui_date_picker);
  
      const vm = app.mount('#app');
  </script>
  ```

- 把訂單日期改為以下語法

  ```html
  <jquery-ui-date-picker
      v-model="vue_model.OrderDate"
      v-bind:id="'OrderDate'"
      v-bind:date_format="'yy-mm-dd'"
  ></jquery-ui-date-picker>
  ```
- vue
  - update_vue_model()
    - 將給定 vue_model 值的語法放回呼叫 update_vue_model() 的地方
    - 原本對訂單日期的處理，就交給 component jquery-ui-date-picker 去處理
    - 刪除 update_vue_model()

  ```js
  const calculate = function () {
      CustomFetch.PostJson(calculate_url, vue_model.value)
                  .then(data => vue_model.value = data);
  }
  
  const submit_form = function() {
      CustomFetch.PostJson(post_url, vue_model.value)
                  .then(data => vue_model.value = data);
  }
  ```

---

這篇先到這裡，下一篇來看看 下拉選單連動 + jQuery UI Selectmenu !
