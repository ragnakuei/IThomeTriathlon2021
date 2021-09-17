using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day27;

namespace Project.Controllers
{
    public class Day27Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            // 給定下拉選單所有項目
            ViewBag.OrderItemsJson = GetOrderItems().ToJson();

            // 透過 ViewBag 給定前端 Orderitem 空物件 !
            ViewBag.EmptyItemJson = new OrderItem().ToJson();

            // 把範例簡單化，預先給定既有的資料
            var vm = new ViewModel
                     {
                         OrderDate = DateTime.Now,

                         Items = new OrderItem[]
                                 {
                                     new () { OrderItemId = 1, UnitPrice = 600, Quantity = 1},
                                     new () { OrderItemId = 2, UnitPrice = 300, Quantity = 1},
                                     new () { OrderItemId = 3, UnitPrice = 1000, Quantity = 1},
                                     new (),
                                 },
                     };

            return View(vm);
        }

        private Option[] GetOrderItems()
        {
            return new Option[]
                   {
                       new() { Value = 1, Text = "系統重灌" },
                       new() { Value = 2, Text = "交通費" },
                       new() { Value = 3, Text = "客制化服務" },
                   };
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
