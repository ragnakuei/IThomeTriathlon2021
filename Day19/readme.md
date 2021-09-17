# Day19 - 輕前端 Vue - 複雜型別 object + collection


## Case01


View 內容如下：

- 內容跟 Day08 / Day11 差不多，主要是 js 多了 ajax 的處理 !
- OrderDate 欄位的部份，我選擇在前端把日期後面的 T 跟時間 刪掉

    ```html
    <div id="app" v-cloak>
        <form autocomplete="off"
              v-on:submit.prevent="submit_form">
            <p>
                <label for="OrderDate">訂單日期：</label>
                <input type="date"
                       v-model="vue_model.OrderDate"
                       id="OrderDate" />
            </p>
            <div>
                <label>訂單項目</label>
                <p v-for="(item, index) in vue_model.Items"
                   v-bind:key="index">
                    <input type="text"
                           v-model="vue_model.Items[index]" />
                </p>
            </div>
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
                    const vue_model = reactive(@Html.Raw(Model.ToJson()));

                    const submit_form = function() {
                        fetch(post_url, {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify(vue_model),
                        })
                        .then(response => response.json())
                        .then(data => {
                            vue_model.OrderDate = data?.OrderDate?.split('T')[0];
                            vue_model.Items = data?.Items;
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

---

關於前端處理 Date 的其他方式
- 有興趣的人可以玩看看，在 Asp.Net Core MVC 加上 [Custom JsonConverter](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to)，

這篇先到這裡，下一篇來看 `複雜型別 object + object collection` !
