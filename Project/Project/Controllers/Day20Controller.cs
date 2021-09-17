using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day20;

namespace Project.Controllers
{
    public class Day20Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            var vm = new ViewModel
                     {
                         OrderDate = null,
                         Items     = Enumerable.Repeat(new OrderItem(), 3).ToArray(),
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
