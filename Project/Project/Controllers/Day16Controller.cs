using Microsoft.AspNetCore.Mvc;
using Project.Models.Day16;

namespace Project.Controllers
{
    public class Day16Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case01([FromForm]ViewModel vm)
        {
            // 避免 Model Binding 後的誤判，導致 Helper 抓錯 Index 的資料
            ModelState.Clear();
            return View(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrderItem([FromForm]int index)
        {
            ViewData["OrderItemIndex"] = index;

            return PartialView("/Views/Day16/OrderItem.cshtml", new OrderItem() );
        }
    }
}
