# Day07 - 套用 Html Helper - 複雜型別 object

這篇開始使用 Html Helper 來 Render 出需要的 Html 控制項 name，方便在 Submit Form 時，將資料拋回後端 !

為求簡單驗証，當後端收到前端拋回的資料後，就直接放回原頁面，來確認所輸入的資料是否正確 !

接下來，直接來看 Html Helper 複雜型別 object !

---

## Case01

跟 Day03 Case01 範例差不多，差異如下：

- ViewModel

    加上 Display Attribute，讓 LabelFor 可以取出對應的 Name

    ```csharp
    public class ViewModel
    {
        [Display(Name = "編號")]
        public int Id { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }
    }
    ```

- View

    套用 Html Helper

    ```html
    @using (Html.BeginForm())
    {
        <p>
            @Html.LabelFor(model => model.Id)
            @Html.TextBoxFor(m => m.Id, new { type = "number", step = 1, min = 0 })
        </p>
        <p>
            @Html.LabelFor(model => model.Name)
            @Html.TextBoxFor(m => m.Name)
        </p>
        <p>
            <button type="submit">送出</button>
        </p>
    }
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<form action="/Day07/Case01" method="post">    
    <p>
        <label for="Id">編號</label>
        <input id="Id" min="0" name="Id" step="1" type="number" value="1">
    </p>
    <p>
        <label for="Name">姓名</label>
        <input id="Name" name="Name" type="text" value="A">
    </p>
    <p>
        <button type="submit">送出</button>
    </p>
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8A7ZajjSkvVDucDkty34oK7Kp5biaPr_zr_L49d6sOTvKGJB78nig2ULh8VxpBWFu80Eqii_fqJFFvXq1YHOxHdcZKw-gi-ZtPOhvJWi1kwprZsZTyLXVsO0Fgt7IVRuL9RrDGacz_XiFnsMkbOCvWk">
</form>
```

---

## Case02

跟 Day03 Case02 範例差不多，差異如下：

- ViewModel

    加上 Display Attribute，讓 LabelFor 可以取出對應的 Name

    ```csharp
    public class ViewModel02
    {
        // ...

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public Address Address { get; set; }
    }

    public class Address
    {
        /// <summary>
        /// 縣市
        /// </summary>
        [Display(Name = "縣市")]
        public string City { get; set; }

        /// <summary>
        /// 鄉鎮
        /// </summary>
        [Display(Name = "鄉鎮")]
        public string TownShip { get; set; }

        /// <summary>
        /// 詳細
        /// </summary>
        [Display(Name = "詳細")]
        public string Detail { get; set; }
    }
    ```

- View

    套用 Html Helper

    ```html
    ...

    <div>
        @Html.LabelFor(model => model.Address)
        <p>
            @Html.LabelFor(model => model.Address.City)
            @Html.TextBoxFor(m => m.Address.City)
        </p>
        <p>
            @Html.LabelFor(model => model.Address.TownShip)
            @Html.TextBoxFor(m => m.Address.TownShip)
        </p>
        <p>
            @Html.LabelFor(model => model.Address.Detail)
            @Html.TextBoxFor(m => m.Address.Detail)
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
        <input id="Address_City" name="Address.City" type="text" value="b">
    </p>
    <p>
        <label for="Address_TownShip">鄉鎮</label>
        <input id="Address_TownShip" name="Address.TownShip" type="text" value="c">
    </p>
    <p>
        <label for="Address_Detail">詳細</label>
        <input id="Address_Detail" name="Address.Detail" type="text" value="d">
    </p>
</div>
```




可以看到 Html Helper 所指定的 Expression 會在 Render 為 Html 後給定的 Expression 內所指定的 property name，這樣可以方便 submit form 時，將資料拋回後端 !

---

這篇先到這裡，下一篇來看 `複雜型別 object + collection` !
