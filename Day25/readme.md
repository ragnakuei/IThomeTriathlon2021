# Day25 - 加上 jQuery UI Selectmenu

這一篇來把上一篇範例`訂單項目`的`名稱`改為下拉選單的`項目`

下拉選單要使用套件 jQuery UI Selectmenu

---

## Case01

ViewModel

- 把 OrderItem Name Property 改為以下 Property

  ```csharp
  ...

  /// <summary>
  /// 訂單項目編號
  /// </summary>
  [Display(Name = "訂單項目編號")]
  public int? OrderItemId { get; set; }

  ...
  ```

Controller

- 建立取得`訂單項目`清單 method

  ```csharp
  private Option[] GetOrderItems()
  {
      return new Option[]
              {
                  new() { Value = 1, Text = "系統重灌" },
                  new() { Value = 2, Text = "交通費" },
                  new() { Value = 3, Text = "客制化服務" },
              };
  }
  ```

- Get Case01 Action

  - 給定下拉選單所有訂單項目
  - 把範例簡單化，預先給定既有的資料

  ```csharp
  [HttpGet]
  public IActionResult Case01()
  {
      // 給定下拉選單所有訂單項目
      ViewBag.OrderItemsJson = GetOrderItems().ToJson();

      ...

      // 把範例簡單化，預先給定既有的資料
      var vm = new ViewModel
                {
                    Items = new OrderItem[]
                            {
                                new () { OrderItemId = 1, UnitPrice = 600, Quantity = 1},
                                new () { OrderItemId = 2, UnitPrice = 300, Quantity = 1},
                                new () { OrderItemId = 3, UnitPrice = 1000, Quantity = 1},
                                new (),
                            },
                };

      return View(vm);
  }
  ```

View

- 把訂單項目標題的`名稱`，改為`項目`

  ```html
  <th>
      <label>項目</label>
  </th>
  ```

- 把訂單項目`名稱` input 改為綁定至`訂單項目編號`
- 下拉選單給定所有的訂單項目
- 額外建立一個自訂的 attribute `item-index` 來存放`訂單項目`的 index
  - 目的是為了在 Selectmenu 變更時，可以正確把值回寫回對應的訂單項目的`訂單項目編號`

  ```html
  
  <td>
      <select name="select-menu"
              v-bind:item-index="index"
              v-model="item.OrderItemId">
          <option value="null">請選擇</option>
          <option v-for="order_item in order_items"
                  v-bind:value="order_item.Value" >
            {{ order_item.Text }}
          </option>
      </select>
  </td>

    ```

- vue
  - 以變數存放所有`訂單項目`
  - onMounted 設定初始化 Selectmenu 及 select 某個下拉選單項目的動作

  ```js
  
  const order_items = @(Html.Raw(ViewBag.OrderItemsJson));

  onMounted(() => {
      $('[name="select-menu"]').selectmenu({
          width: 200,
          select: function (event, ui) {

              // 從 item-index 取出 Items 內對應的 Item
              const item_index = event.target.attributes.getNamedItem('item-index').value;
              const item = vue_model.value.Items[parseInt(item_index)];

              // 更新其 OrderItemId
              item.OrderItemId = parseInt(ui.item.value);
          }
      });
  })

  
  return {
              order_items,
  }
  ```

---

這篇先到這裡，下一篇來看看把 jQuery UI Selectmenu 放到 Vue Component 內 !
