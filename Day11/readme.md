# Day11 - 套用 Tag Helper - 複雜型別 object + collection

本篇 Controller、ViewModel 跟 Day08 範例差不多，差異如下

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
            @foreach(var item in Model.Items)
            {
                <p>
                    <input type="text"
                        name="Items"
                        asp-for="@item" />
                </p>
            }
        </div>
        <p>
            <button type="submit">送出</button>
        </p>
    </form>
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<form method="post" action="/Day11/Case01">
    <p>
        <label for="OrderDate">訂單日期</label>
        <input type="date" id="OrderDate" name="OrderDate" value="2021-05-12">
    </p>
    <div>
        <label for="Items">訂單項目</label>
            <p>
                <input type="text" name="Items" id="item" value="i">
            </p>
            <p>
                <input type="text" name="Items" id="item" value="u">
            </p>
            <p>
                <input type="text" name="Items" id="item" value="y">
            </p>
    </div>
    <p>
        <button type="submit">送出</button>
    </p>
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8JZKsziTm_FAnuczkhH_uBrkpOr7ADzb3TIFWYKLPUY1mp07qSXVSkR2a43i6HYJ2q_fl11RD3xBxb8u7LduvD1cJRlNvJb07jsppyMzE09ZCEtsL0a17vyefALhK89AX6GeMErYps9vqPUNppMCEZc"></form>
```

這個 Case 完美解決 Html Helper 之前提到的二個問題 !

---

## Case02

- View

    使用 Tag Helper

    ```html
    ...
    <div>
        <label asp-for="Items"></label>
        @for (int i = 0; i < Model.Items.Length; i++)
        {
            <p>
                <input type="text"
                        asp-for="Items[i]" />
            </p>
        }
    </div>
    ...
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
...
<div>
    <label for="Items">訂單項目</label>
        <p>
            <input type="text" id="Items_0_" name="Items[0]" value="4">
        </p>
        <p>
            <input type="text" id="Items_1_" name="Items[1]" value="5">
        </p>
        <p>
            <input type="text" id="Items_2_" name="Items[2]" value="6">
        </p>
</div>
...
```

再次強調
這個 Case 的缺點就是如果 index 不連續
則 index 不連續之後的資料，都會 Binding 失敗 !

---

相較於 Html Helper，這邊可以看得出 Tag Helper 更有彈性的地方

針對特定的 html dom 的 asp-for 可以給定二種型態的格式
1. Model 的 Property
2. 以 @開頭 給定變數

這篇先到這裡，下一篇來看 `複雜型別 object + object collection` !
