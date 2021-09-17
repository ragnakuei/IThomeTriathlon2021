# Day21 - 動態 新增/刪除 Collection 項目(四) - 輕前端 Vue

## Case01

與 Day20 重點差異的部份：

- Controller 內 Action：

    ```csharp
    [HttpGet]
    public IActionResult Case01()
    {
        // 透過 ViewBag 給定前端 Orderitem 空物件 !
        ViewBag.EmptyItemJson = new OrderItem().ToJson();

        var vm = new ViewModel
                    {
                        OrderDate = null,

                        // Array 先給定空陣列後，前端就可以不用額外處理 !
                        Items     = Array.Empty<OrderItem>(),
                    };

        return View(vm);
    }

    // ...
    ```

- View ：

  - 加上新增訂單項目

    ```html
    <th>
        <button type="button"
                v-on:click="add_item">
            新增
        </button>
    </th>
    ```

  - 加上刪除訂單項目

    ```html
    <td>
        <button type="button"
                v-on:click="del_item(index)">
            刪除
        </button>
    </td>
    ```

   - Vue 的部份

      - 新增 / 修改 的部份
        - 避免新增都加入相同 reference object，先將 empty_item 轉成 json 字串，再轉回 object !        
      ```js
      // ...

        setup(){

            // ...

            const empty_item = @(Html.Raw(ViewBag.EmptyItemJson));

            const add_item = function() {
                const cloned_empty_item = JSON.parse(JSON.stringify(empty_item));
                vue_model.Items?.push(cloned_empty_item);
            }

            const del_item = function(index) {
                vue_model.Items?.splice(index, 1);
            }

            // ...

            return {
                // ...

                add_item,
                del_item,
                
                // ...
            }
        }

      // ...
      ```

---

這篇先到這裡

因為不使用 Html Helper / Tag Helper，所以無法從 `__RequestVerificationToken` 取出 Antifogery Token

下一篇來看看另一種加上 Antiforgery Token 的做法 !
