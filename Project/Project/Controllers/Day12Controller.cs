using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day12;

namespace Project.Controllers
{
    public class Day12Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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

        [HttpPost]
        public IActionResult Case01([FromForm]ViewModel vm)
        {
            return View(vm);
        }
    }
}
