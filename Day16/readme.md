# Day16 - Ajax 加上 Antiforgery Token (一)

這篇內容延續上一篇的部份，來加上 Antiforgery Token 的給定及驗証 !

---

## Case01

在 Action AddOrderItem() 的部份，加上 ValidateAntiForgeryToken Attribute

```csharp
[HttpPost, Route("api/[controller]/[action]")]
[ValidateAntiForgeryToken]
public IActionResult AddOrderItem([FromForm]int index)
{
    ViewData["OrderItemIndex"] = index;

    return PartialView("/Views/Day16/OrderItem.cshtml", new OrderItem() );
}
```

此時，在 ajax 未給定 Antiforgery Token 的情況下，發送 request 會發生 http status code 400 的錯誤

View 的 ajax request header 加上給定 Antiforgery Token 的語法

- 預設來說，form tag helper 會自動產生 input name 為 __RequestVerificationToken 的 dom，這個 dom 存放的值，就是 Antiforgery Token
- request header 加上 key 為 RequestVerificationToken ， value 為上述 Antiforgery Token 的值

```js
window.AntiForgeryToken = document.querySelectorAll('input[name="__RequestVerificationToken"]')[0].value;

window.AddItem = function () {

    const requestBody = new URLSearchParams();
    requestBody.append('index', ItemsCount);

    fetch(AddItemUrl, {
        method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'RequestVerificationToken': AntiForgeryToken,
            },
            body: requestBody,
        })
    .then(response => response.text())
    .then(data => {
        $('#Items').append(data);
        ItemsCount++;
    })
}
```

此時，發送 request 到後端，就會正常了 !

---

這篇先到這裡，下一篇來看看進入輕前端 Vue 前的範例 !
