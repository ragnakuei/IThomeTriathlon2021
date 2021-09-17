using Microsoft.AspNetCore.Mvc;
using Project.Models.Day17;

namespace Project.Controllers
{
    public class Day17Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Case01([FromForm]ViewModel vm)
        {
            // 避免 Model Binding 後的誤判，導致 Helper 抓錯 Index 的資料
            ModelState.Clear();
            Calculate(vm);
            return View(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrderItem([FromForm]int index)
        {
            ViewData["OrderItemIndex"] = index;

            return PartialView("/Views/Day17/OrderItem.cshtml", new OrderItem());
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate([FromForm]ViewModel vm)
        {
            if (vm?.Items?.Length > 0 == false)
            {
                return Ok(vm);
            }

            vm.SubTotalAmount = 0;
            foreach (var item in vm.Items)
            {
                item.Amount = item.UnitPrice * item.Quantity;

                vm.SubTotalAmount += item.Amount.GetValueOrDefault();;
            }

            vm.Tax         = vm.SubTotalAmount * 0.05m;
            vm.TotalAmount = vm.SubTotalAmount * 1.05m;

            return Ok(vm);
        }
    }
}
