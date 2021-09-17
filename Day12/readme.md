# Day12 - 套用 Tag Helper - 複雜型別 object + object collection

接下來開始著重使用 Tag Helper 在 Html 長出需要的 Html 控制項 name !

本篇 Controller、ViewModel 跟 Day09 一樣

依照 View 的差異，拆成不同 Case 來看 !

---

## Case01

- View

    使用 Tag Helper

    ```html
    <form asp-action="Case01"
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
                </tr>
                </thead>
                <tbody>
                @for (int i = 0; i < Model.Items?.Length; i++)
                {
                    <tr>
                        <td>
                            <input type="text"
                                asp-for="Items[i].Name" />
                        </td>
                        <td>
                            <input type="number"
                                step=1
                                min=0
                                asp-for="Items[i].Quantity" />
                        </td>
                    </tr>
                }
                </tbody>
            </table>

        </div>
        <p>
            <button type="submit">送出</button>
        </p>
    </form>
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<form action="/Day12/Case01" method="post">    <p>
        <label for="OrderDate">訂單日期</label>
        <input type="date" id="OrderDate" name="OrderDate" value="2021-05-07">
    </p>
    <div>
        <label for="Items">訂單項目</label>
        <table>
            <thead>
            <tr>
                <th>
                    <label for="Name">名稱</label>
                </th>
                <th>
                    <label for="Quantity">數量</label>
                </th>
            </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <input type="text" id="Items_0__Name" name="Items[0].Name" value="b">
                    </td>
                    <td>
                        <input type="number" step="1" min="0" id="Items_0__Quantity" name="Items[0].Quantity" value="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="Items_1__Name" name="Items[1].Name" value="c">
                    </td>
                    <td>
                        <input type="number" step="1" min="0" id="Items_1__Quantity" name="Items[1].Quantity" value="3">
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="Items_2__Name" name="Items[2].Name" value="d">
                    </td>
                    <td>
                        <input type="number" step="1" min="0" id="Items_2__Quantity" name="Items[2].Quantity" value="4">
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
    <p>
        <button type="submit">送出</button>
    </p>
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8BeKebzmhD5Pmy2bGJRwhhKT8Kxj5cFT9TMWMe5MLg3hAZMQvqb7T2MN-fAXNlKuqMrFrAWmPJnMmBiBuDA9petFx_TTn_bQXytOG0TKwkg7CnhC44o112SHqQAJN7wsSXixA8jVjplVbvD6iEschHM">
</form>
```

再次強調
這個 Case 的缺點就是如果 index 不連續
則 index 不連續之後的資料，都會 Binding 失敗 !

---

到這邊先做個簡單的整理

當套用 Html Helper / Tag Helper，注意 Render 後的 Html 控制項 name，只要符合規則，在 Submit Form 後，後端進行 Model Binding 時，就不會有太大的問題 !

---

這篇先到這裡，下一篇來看 `動態 新增/刪除 Collection 項目` !
