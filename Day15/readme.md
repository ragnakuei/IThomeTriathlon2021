# Day15 - 動態 新增/刪除 Collection 項目(三) - Tag Helper

這篇調整的方向只是把上一篇的 Html Helper 改為 Tag Helper 而已 !

---

## Case01

Controller 內的 Action 與上一篇相同

View 內容如下：

```html
<form asp-action="Case01"
      autocomplete="off"
      method="post">
    <p>
        <label asp-for="OrderDate"></label>
        <input type="date"
               asp-for="OrderDate" />
    </p>
    <div>
        <label asp-for="Items"></label>
        <table>
            <thead>
            <tr>
                <th>
                    <label asp-for="Items.FirstOrDefault().Name"></label>
                </th>
                <th>
                    <label asp-for="Items.FirstOrDefault().Quantity"></label>
                </th>
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

                    <partial name="OrderItem"
                             for="Items[i]"
                             view-data="ViewData" />
                }
            </tbody>
        </table>

    </div>
    <p>
        <button type="submit">送出</button>
    </p>
</form>

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

```html
@model Project.Models.Day15.OrderItem
@{
    var itemIndex = ViewData["OrderItemIndex"];
}
<tr>
    <input type="hidden"
           name="Items.index"
           value="@(itemIndex)">
    <td>
        <input type="text"
               name="Items[@(itemIndex)].Name"
               asp-for="Name" />
    </td>
    <td>
        <input type="number"
               name="Items[@(itemIndex)].Quantity"
               step=1
               min=0
               asp-for="Quantity" />
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

---

這篇先到這裡，下一篇來看 Ajax 如何給定 Antiforgery Token 的部份 !
