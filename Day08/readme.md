# Day08 - 套用 Html Helper - 複雜型別 object + collection

## Case01

跟 Day05 範例差不多，差異如下：

- Controller

    於 Get 時，先寫死固定 3 個 Items !

    ```csharp
    [HttpGet]
    public IActionResult Case01()
    {
        var vm = new ViewModel
                    {
                        OrderDate = null,
                        Items     = new string[3],
                    };

        return View(vm);
    }
    ```

- ViewModel

    加上 Attribute，讓 Html Helper 做出更多調整

    ```csharp
    public class ViewModel
    {
        [Display(Name                   = "訂單日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "訂單項目")]
        public string[] Items { get; set; }
    }
    ```

- View

    改為使用 Html Helper

    ```html
    @using (Html.BeginForm())
    {
        <p>
            @Html.LabelFor(model => model.OrderDate)
            @Html.EditorFor(m => m.OrderDate)
        </p>
        <div>
            @Html.LabelFor(model => model.Items)
            @for (int i = 0; i < Model.Items.Length; i++)
            {
                <p>
                    @Html.TextBoxFor(m => m.Items[i])
                </p>
            }
        </div>
        <p>
            <button type="submit">送出</button>
        </p>
    }
    ```

輸入資料 & Submit 後，View Render 出來的結果

```html
<form action="/Day08/Case01" method="post">    
    <p>
        <label for="OrderDate">訂單日期</label>
        <input id="OrderDate" name="OrderDate" type="date" value="2021-05-14">
    </p>
    <div>
        <label for="Items">訂單項目</label>
            <p>
                <input id="Items_0_" name="Items[0]" type="text" value="a">
            </p>
            <p>
                <input id="Items_1_" name="Items[1]" type="text" value="b">
            </p>
            <p>
                <input id="Items_2_" name="Items[2]" type="text" value="c">
            </p>
    </div>
    <p>
        <button type="submit">送出</button>
    </p>
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8A7ZajjSkvVDucDkty34oK65oUymqQEsOhpDvYoLy-ea7g0FL8lhRxPMhL5oJqcuOuOAS5mApO8RTk7jBgY0_3xvyJSjF3NFZxlikZUwq4dHQ04u78abz2-aDeriWaGtpxr8-QEynDDCO8z8Cepg18A">
</form>
```

## 後記

我曾經想用 foreach + Html Helper 來達成

```html
@using (Html.BeginForm())
{
    <p>
        @Html.LabelFor(model => model.OrderDate)
        @Html.TextBoxFor(m => m.OrderDate)
    </p>
    <div>
        @Html.LabelFor(model => model.Items)
        @foreach(var Items in Model.Items)
        {
            <p>
                @Html.TextBoxFor(m => Items)
                @* @Html.TextBox(nameof(Model.Items), Items) *@
            </p>
        }
    </div>
    <p>
        <button type="submit">送出</button>
    </p>
}
```

Post 後，在 Action 內，值可以成功回傳

但是一回到 View 之後，Collection 的值，就只會抓 index 0 的值放到 value 中

其實這突顯了二個問題

1. For 結尾的 Html Helper 要自訂 name，有時會失去原本變數的所代表的意義 !
2. TextBoxFor / EditorFor 如果指定了 Collection，只會給定 index 0 的值

有興趣的人可以試看看 !

---

這篇先到這裡，下一篇來看 `複雜型別 object + object collection` !
