using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day23;

namespace Project.Controllers
{
    public class Day23Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            // 透過 ViewBag 給定前端 Orderitem 空物件 !
            ViewBag.EmptyItemJson = new OrderItem().ToJson();

            var vm = new ViewModel
                     {
                         OrderDate = null,

                         // Array 先給定空陣列後，前端就可以不用額外處理 !
                         Items = Array.Empty<OrderItem>(),
                     };

            return View(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult PostCase01([FromBody]ViewModel vm)
        {
            Calculate(vm);
            return Ok(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate([FromBody]ViewModel vm)
        {
            if (vm?.Items?.Length > 0 == false)
            {
                return Ok(vm);
            }

            vm.SubTotalAmount = 0;
            foreach (var item in vm.Items)
            {
                item.Amount = item.UnitPrice * item.Quantity;

                vm.SubTotalAmount += item.Amount.GetValueOrDefault();
            }

            vm.Tax         = vm.SubTotalAmount * 0.05m;
            vm.TotalAmount = vm.SubTotalAmount * 1.05m;

            return Ok(vm);
        }
    }
}
