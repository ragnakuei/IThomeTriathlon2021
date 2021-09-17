# Day22 - Ajax 加上 Antiforgery Token (二)

## Case01

與 Day21 重點差異的部份：

- Controller 內 Action：

    加上 ValidateAntiForgeryToken Attribute

    ```csharp
    // ...

    [HttpPost, Route("api/[controller]/[action]")]
    [ValidateAntiForgeryToken]
    public IActionResult PostCase01([FromBody]ViewModel vm)
    {
        return Ok(vm);
    }

    // ...
    ```

- View ：

  - 新增 Partial View _Antiforgery.cshtml

    ```html
    @inject Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf
    @functions{
        private string GetAntiXsrfRequestToken()
        {
            return Xsrf.GetAndStoreTokens(Context).RequestToken;
        }
    }

    <script>
        window.Antiforgery = {};
        Antiforgery.RequestVerificationToken = '@(GetAntiXsrfRequestToken())';
    </script>
    ```

  - Case01 
  
    View 加上引用上述的 Partial View

    ```html
    ...

    @section Scripts
    {
        <partial name="_Antiforgery"/>
        <script>
        const app = createApp({
            setup(){

    ...
    ```

    fetch 加上 Header RequestVerificationToken 

    ```js
    // ...
        fetch(post_url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken' : Antiforgery.RequestVerificationToken
            },
            body: JSON.stringify(vue_model),
        })

    // ...
    ```

---

參考資料：[Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery)


下一篇來看看把 Day17 範例改用 輕前端 Vue !
