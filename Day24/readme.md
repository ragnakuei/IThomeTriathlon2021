# Day24 - 抽取 js 共用元件

---

## Case01

與 Day23 範例的差異，就是把 js fetch 的語法 extract 成 function

CustomFetch.js

- 除了把原本的語法 extract 出來，額外再加上 .catch()，來達到基本的共用處理邏輯 !

  ```js
  window.CustomFetch = {};
  CustomFetch.PostJson = function (url, data) {
    return fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        RequestVerificationToken: Antiforgery.RequestVerificationToken,
      },
      body: JSON.stringify(data),
    })
      .then((response) => response.json())
      .catch((error) => console.log(error));
  };
  ```

View

- 引用 CustomFetch.js 
  
  因為 CustomFetch 裡面會呼叫 Antiforgery 物件資料
  依照我個人習慣
  我會把 CustomFetch 的引用，放在 引用 Antiforgery 的下方 !

  ```html
  ...

  <partial name="_Antiforgery" />
  <script src="/lib/CustomFetch.js?20210608001"></script>

  ...
  ```

- 把原本 fetch 的語法，改為呼叫 CustomFetch.PostJson(url, request_body).then() 的語法

  ```html
  ...
      <script>
        const app = createApp({
          setup(){

  ...

            const calculate = function () {
                CustomFetch.PostJson(calculate_url, vue_model.value)
                          .then(data => update_vue_model(data));
            }

  ...

            const submit_form = function() {
                CustomFetch.PostJson(post_url, vue_model.value)
                          .then(data => update_vue_model(data));
            }

  ...
  ```

---

有興趣的人，也可以試試改用 partial view 的方式，來呼叫 js 共用元件
就像 Antifogery 那樣 !

這篇先到這裡，下一篇來看看整合 jQuery UI 的部份 !
