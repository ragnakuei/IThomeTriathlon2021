# Day23 - Day17 改為輕前端範例

---

## Case01

與 Day17 範例的差異，除了從 Razor Tag Helper 改為 輕前端外，主要還有以下的部份

- Controller
  - 刪除 Action AddOrderItem()
  - PostCase01 改為讀取 Json 格式

- View
  - 刪除 OrderItem.cshtml
  - 所有 ajax 改為 post json 格式
  - 刪除 Guid、金額、小計、稅金、總計 的 hidden 欄位
  - js script 
    - 刪除 function RenewAmounts() - 因為在計算完畢後，不需要手動把值放回 html dom 中
    - 取得 CSRF Token 的方式

有興趣的人，可以細看與 Day17 範例的差異 !

---

這篇先到這裡

因為 fetch 開始出現重複的程式碼

下一篇來看看把 fetch 抽取成共用元件 !

