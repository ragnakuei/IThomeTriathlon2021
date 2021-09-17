# Day26 - 輕前端 Component - jQuery UI Selectmenu

這個範例把上個範例的 jQuery UI Selectmenu 放到 vue component 內

就可以把 jQuery UI 的關注部份給縮小 !

---

## Case01

建立 jquery-ui-select-menu.js

- 把訂單項目下拉選單放在這個 component 內 !
- 因為 component 可視為與 Domain 無關，就可以做為共用元件，因此變數命名上，就不需要有 Domain 意圖的名稱了 !

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
          options: Array,
          modelValue: String,
          width: Number,
      },
      setup(props, {emit}) {

          let dom = null;

          onMounted(() => {
              dom = $("#"+ props.id);
              dom.selectmenu({
                  width: props.width,
                  change: function (event, ui) {
                      emit('update:modelValue', parseInt(ui.item.value));
                  }
              });
          })

          return {
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

- 訂單項目下拉選單就改為使用上述的 component

  - v-model - 直接綁定指定的 Property，因此不需要上個範例的 item-index 相關的語法了 !
  - id - 主要是用於 jQuery UI Selectmenu 初始化要用，避免給定相同的 id
  - options - 下拉選單項目。項目的 Text 為顯示文字、Value 為項目的值 !
  - width - 指定下拉選單的寬度

  ```html
    <td>
      <jquery-ui-select-menu
          v-model="item.OrderItemId"
          v-bind:id="'select-menu-'+index"
          v-bind:options="order_items"
          v-bind:width=200
      ></jquery-ui-select-menu>
  </td>
  ```

---

這篇先到這裡，下一篇來看看把 jQuery UI Selectmenu 放到 Vue Component 內 !
