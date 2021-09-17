# Day18 - 輕前端 Vue - 複雜型別 object

我先說明一下

我用輕前端 Vue 的目的，不是把整個網站都改用輕前端，而是為了把複雜的 js 取值、給值的邏輯交由 Vue Model Binding 的機制處理，進而省去過多不必要的語法 !

在 Vue 這個部份來說，我還在學習中，所以文章內容不會提到該怎麼寫 Vue，我會儘量使用 Vue 3  Composition API 

另外，debug 時，記得持續開啟 chrome devtools，看看 console 是否會報錯 !

---

## Case01

Controller 內的

- Get Action 內容如下：
  - 為了讓 Vue 起始能 Binding 成功，進入 Get 頁面時，要一併給定 ViewModel 預設值 !

    ```csharp
    [HttpGet]
    public IActionResult Case01()
    {
        return View(new ViewModel());
    }
    ```

- Post Action 內容如下：

  - 只要是 ajax 所指定的 Action，該 Action 的 Route 都會改為 api 開頭，並加上 Post Prefix name
  - ajax Action 的部份，因為需要改成 json 格式，所以從原本的 `FromForm` 改成 `FromBody`

    ```csharp
    [HttpPost, Route("api/[controller]/[action]")]
    public IActionResult PostCase01([FromBody]ViewModel vm)
    {
        return Ok(vm);
    }
    ```

View ：

- 改用輕前端，等於前後端分離，所以前端欄位名稱都要手動給定 !
- 我會切開 C# 與 js / vue 的 coding style
- Razor 的語法的影響限制
  - 只讓 Razor 的語法只套用至 js variable，不會套用至 js function 或 statement 內 !
  - 拆分 component 的方式，以輕前端角度來看，如果想套用 Single File Component，會造成每個頁面都會有編譯的成本，所以我改用 Razor Partial View 或是引用 js 檔 !
- 因為 Vue 的 Model Binding 是針對 js object，所以 ajax request 的部份，全部改為 json 格式

    ```html
    <div id="app" v-cloak>
        <form autocomplete="off"
            v-on:submit.prevent="submit_form">
            <p>
                <label for="id">編號：</label>
                <input type="number"
                       step="1"
                       min="0"
                       id="id"
                       v-model.number="vue_model.id" />
            </p>
            <p>
                <label for="name">姓名：</label>
                <input type="text"
                       id="name"
                       v-model="vue_model.name" />
            </p>
            <p>
                <button type="submit">送出</button>
            </p>
        </form>

        <p>
            <a v-bind:href="prev_url">回上一層</a>
        </p>
    </div>

    @section Scripts
    {
        <script>
            const app = createApp({
                setup(){

                    const post_url = '@Url.Action("PostCase01")';

                    const prev_url = '@Url.Action("Index")';

                    const vue_model = ref(@Html.Raw(Model.ToJson()));

                    const submit_form = function() {
                        fetch(post_url, {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify(vue_model.value),
                        })
                        .then(response => response.json())
                        .then(data => {
                            vue_model.value = data;
                        });
                    }

                    return {
                        post_url,
                        prev_url,

                        vue_model,
                        submit_form,
                    }
                }
            });

            const vm = app.mount('#app');
        </script>
    }
    ```

新增 JsonHelper

```csharp
public static class JsonHelper
{
    public static string ToJson<T>(this T t, bool isCamelCase = true)
    {
        var jsonSerializerOptions = new JsonSerializerOptions();

        if (isCamelCase)
        {
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }

        return JsonSerializer.Serialize(t, jsonSerializerOptions);
    }
}
```

執行網站後，可以看出 ajax 打回後端，取回時，直接把資料放回 js object 就好 !

換句話說，不需要從 html 把 html 控制項的 value 取出，等後端處理完畢後，再放回 html 控制項中 !

整個清爽許多了 !!

---

這篇先到這裡，下一篇來看 `複雜型別 object + collection` !
