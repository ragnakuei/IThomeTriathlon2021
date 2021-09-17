# Day20 - 輕前端 Vue - 複雜型別 object + object collection

## Case01

View 內容如下：

- 內容跟 Day09 / Day12 差不多，主要是 js 多了 ajax 的處理 !

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
                <table>
                    <thead>
                    <tr>
                        <th>
                            <label>名稱</label>
                        </th>
                        <th>
                            <label>數量</label>
                        </th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr v-for="(item, index) in vue_model.Items"
                        v-bind:key="index">
                        <td>
                            <input type="text"
                                   v-model="item.Name" />
                        </td>
                        <td>
                            <input type="number"
                                   step=1
                                   min=0
                                   v-model="item.Quantity" />
                        </td>
                    </tr>
                    </tbody>
                </table>
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

這篇先到這裡，下一篇來看 `動態 新增/刪除 Collection 項目` !
