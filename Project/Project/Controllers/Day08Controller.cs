using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day08;

namespace Project.Controllers
{
    public class Day08Controller : Controller
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
                         Items     = new string[3],
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
