using Microsoft.AspNetCore.Mvc;
using Project.Models.Day15;

namespace Project.Controllers
{
    public class Day15Controller : Controller
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
        public IActionResult AddOrderItem([FromForm]int index)
        {
            ViewData["OrderItemIndex"] = index;

            return PartialView("/Views/Day15/OrderItem.cshtml", new OrderItem() );
        }
    }
}
