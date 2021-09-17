# Day09 - 套用 Html Helper - 複雜型別 object + object collection

## Case01

跟 Day06、Day08 範例差不多，重點差異如下：

- Controller

    於 Get 時，就給定 object colletion 的數量。

    註：之後的範例會改動態的 !

    ```csharp
    [HttpGet]
    public IActionResult Case01()
    {
        var vm = new ViewModel
                    {
                        OrderDate = null,
                        Items     = Enumerable.Repeat(new OrderItem(), 3).ToArray()
                    };

        return View(vm);
    }
    ```

- ViewModel

    - 加上 Display Attribute

    ```csharp
    /// <summary>
    /// 訂單項目
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 名稱
        /// </summary>
        [Display(Name = "名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Name = "數量")]
        public int? Quantity { get; set; }
    }
    ```

- View

    改為使用 Html Helper

    ```html
    ...
    <table>
        <thead>
        <tr>
            <th>@Html.LabelFor(m => m.Items.FirstOrDefault().Name)</th>
            <th>@Html.LabelFor(m => m.Items.FirstOrDefault().Quantity)</th>
        </tr>
        </thead>
        <tbody>
        @for (int i = 0; i < Model.Items?.Length; i++)
        {
            <tr>
                <td>
                    @Html.TextBoxFor(m => Model.Items[i].Name)
                </td>
                <td>
                    @Html.TextBoxFor(m => Model.Items[i].Quantity,  new { type = "number", step = 1, min = 0 })
                </td>
            </tr>
        }
        </tbody>
    </table>
    ...
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
...
<tbody>
    <tr>
        <td>
            <input id="Items_0__Name" name="Items[0].Name" type="text" value="a">
        </td>
        <td>
            <input id="Items_0__Quantity" min="0" name="Items[0].Quantity" step="1" type="number" value="1">
        </td>
    </tr>
    <tr>
        <td>
            <input id="Items_1__Name" name="Items[1].Name" type="text" value="b">
        </td>
        <td>
            <input id="Items_1__Quantity" min="0" name="Items[1].Quantity" step="1" type="number" value="2">
        </td>
    </tr>
    <tr>
        <td>
            <input id="Items_2__Name" name="Items[2].Name" type="text" value="c">
        </td>
        <td>
            <input id="Items_2__Quantity" min="0" name="Items[2].Quantity" step="1" type="number" value="3">
        </td>
    </tr>
</tbody>
...
```

整體來看，就是把 Html 控制項的 name，當成 存取 ViewModel 的路徑

例：`Items[1].Quantity` 就是指 ViewModel 的 Items Array > Index 為 1 之物件 > 物件的 Quantity Property

---

這篇先到這裡，下一篇來看 Tag Helper 的部份 !
