# Day14 - 動態 新增/刪除 Collection 項目(二) - Html Helper

這篇調整的方向是
1. 透過 Partial View 來 Render Collection 項目
2. 透過 ajax 來取回 新增 所需的 html

---

## Case01

Controller 內新增 Action 內容如下：

```csharp
[HttpPost, Route("api/[controller]/[action]")]
public IActionResult AddOrderItem([FromForm]int index)
{
    ViewData["OrderItemIndex"] = index;

    return PartialView("/Views/Day14/OrderItem.cshtml", new OrderItem() );
}
```

View 內容如下：

```html
@using (Html.BeginForm(FormMethod.Post, htmlAttributes: new { autocomplete = "off" }))
{
    <p>
        @Html.LabelFor(model => model.OrderDate)
        @Html.EditorFor(m => m.OrderDate)
    </p>
    <div>
        @Html.LabelFor(model => model.Items)
        <table>
            <thead>
            <tr>
                <th>@Html.LabelFor(m => m.Items.FirstOrDefault().Name)</th>
                <th>@Html.LabelFor(m => m.Items.FirstOrDefault().Quantity)</th>
                <th>
                    <button type="button"
                            onclick="AddItem()">
                        新增
                    </button>
                </th>
            </tr>
            </thead>
            <tbody id="Items">
                @for (int i = 0; i < Model?.Items?.Length; i++)
                {
                    ViewData["OrderItemIndex"] = i;

                    @Html.Partial("OrderItem", Model?.Items[i], ViewData)
                }
            </tbody>
        </table>

    </div>
    <p>
        <button type="submit">送出</button>
    </p>
}

<p>
    <a asp-action="Index">回上一層</a>
</p>

@section Scripts
{
    <script>

        window.ItemsCount = @(Model?.Items?.Length ?? 0);

        window.AddItemUrl = '@Url.Action("AddOrderItem")';

        window.AddItem = function () {

            const requestBody = new URLSearchParams();
            requestBody.append('index', ItemsCount);

            fetch(AddItemUrl, {
                method: 'POST',
                headers: {
                  'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: requestBody,
              })
            .then(response => response.text())
            .then(data => {
                $('#Items').append(data);
                ItemsCount++;
            })
        }

        window.DeleteItem = function (e) {
            const btnDom = e.target;

            const trDom = $(btnDom).parent().parent();

            trDom.remove();
        }
    </script>
}
```

Partial View OrderItem.cshtml 內容如下：

  - 因為 Html.TextBoxFor() 無法自訂 name，所以改用 Html.TextBox()

```html
@model Project.Models.Day14.OrderItem
@{
    var itemIndex = ViewData["OrderItemIndex"];
}
<tr>
    @Html.Hidden("Items.index", itemIndex)
    <td>
        @Html.TextBox($"Items[{itemIndex}].Name", Model.Name)
    </td>
    <td>
        @Html.TextBox($"Items[{itemIndex}].Quantity", Model.Quantity, new { type = "number", step = 1, min = 0 })
    </td>
    <td>
        <button type="button"
                onclick="DeleteItem(event)">
            刪除
        </button>
    </td>
</tr>
```

實際執行後，不管如何動態新增/刪除，在 submit 後，都可以確實傳遞頁面上的資料 !

與上一篇文章的範例相比
- 多了 ajax 維護成本
- 少了維護二份 html 的功 !

---

這篇先到這裡，下一篇來看 Tag Helper 的部份 !
