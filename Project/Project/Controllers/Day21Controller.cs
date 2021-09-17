using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day21;

namespace Project.Controllers
{
    public class Day21Controller : Controller
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
                         Items     = Array.Empty<OrderItem>(),
                     };

            return View(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PostCase01([FromBody]ViewModel vm)
        {
            return Ok(vm);
        }
    }
}
