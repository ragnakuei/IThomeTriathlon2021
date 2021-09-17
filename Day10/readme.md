# Day10 - 套用 Tag Helper - 複雜型別 object

這篇開始使用 Tag Helper 來 Render 出需要的 Html 控制項 name，方便在 Submit Form 時，將資料拋回後端 !

---

## Case01

跟 Day07 範例差不多，差異如下：

- View

    改用 Tag Helper

    ```html
    <form asp-action="Case01" method="post">
        <p>
            <label asp-for="Id"></label>
            <input type="number"
                step="1"
                min="0"
                asp-for="Id" />
        </p>
        <p>
            <label asp-for="Name"></label>
            <input type="text"
                asp-for="Name" />
        </p>
        <p>
            <button type="submit">送出</button>
        </p>
    </form>
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<form method="post" action="/Day10/Case01">
    <p>
        <label for="Id">編號</label>
        <input type="number" step="1" min="0" id="Id" name="Id" value="1">
    </p>
    <p>
        <label for="Name">姓名</label>
        <input type="text" id="Name" name="Name" value="A">
    </p>
    <p>
        <button type="submit">送出</button>
    </p>
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8JZKsziTm_FAnuczkhH_uBoaJWyscDazUmXSOf1nAxIS5q63KAdcxzDoqhsxxMnLc41k9rELoicV4blf5e6FUPpdrUK3o7knd4iKfiCGS66dtHUXRemHX1WPtJ8zU2AVggfoWs7-xGV-0oMGj_9iBYc">
</form>
```

---

## Case02

跟 Day07 Case02 及 上面的 Case 差不多，差異如下：


- View

    套用 Tag Helper

    ```html
    ...

    <div>
        <label asp-for="Address"></label>
        <p>
            <label asp-for="Address.City"></label>
            <input type="text"
                   asp-for="Address.City" />
        </p>
        <p>
            <label asp-for="Address.TownShip"></label>
            <input type="text"
                   asp-for="Address.TownShip" />
        </p>
        <p>
            <label asp-for="Address.Detail"></label>
            <input type="text"
                   asp-for="Address.Detail" />
        </p>
    </div>

    ...
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<div>
    <label for="Address">地址</label>
    <p>
        <label for="Address_City">縣市</label>
        <input type="text" id="Address_City" name="Address.City" value="b">
    </p>
    <p>
        <label for="Address_TownShip">鄉鎮</label>
        <input type="text" id="Address_TownShip" name="Address.TownShip" value="c">
    </p>
    <p>
        <label for="Address_Detail">詳細</label>
        <input type="text" id="Address_Detail" name="Address.Detail" value="d">
    </p>
</div>
```

---

這篇先為 Tag Helper 暖身，下一篇來看 `複雜型別 object + collection` !
