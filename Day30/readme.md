# Day30 - 輕前端 綜合範例

---

## Case01

這個範例綜合了之前提到所有的部份 !

需求就是：把項目的 CRUD 都放在同一個頁面 !
換言之，就是全部都要用 ajax 來達成 !

可以先執行網站，試著走完所有流程
再來思考一下，以這樣的流程，如果用 jQuery 來寫，要如何寫的好維護 !
再來跟輕前端的版本來比較看看，是哪個比較好理解跟維護 !

> 基於 Demo 的用途，把所有訂單放到 static 變數中 !

這個範例還有一些可調整的地方

1. 不要用 partial view _EditOrder.cshtml，改為引用 js 檔 !
2. 新增/編輯 訂單時，思考如何解決因輸入太快，導致 填入的資料 被覆蓋掉 !
3. 加上分頁功能
4. 分頁功能搭配 QueryString

有興趣的人，可以挑戰看看 !

---

這系列的文章就先到這了 !
