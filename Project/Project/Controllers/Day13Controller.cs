using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day13;

namespace Project.Controllers
{
    public class Day13Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Case01()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case01([FromForm]ViewModel vm)
        {
            return View(vm);
        }

        [HttpGet]
        public IActionResult Case02()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case02([FromForm]ViewModel vm)
        {
            return View(vm);
        }

        [HttpGet]
        public IActionResult Case03()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case03([FromForm]ViewModel vm)
        {
            // 避免 Model Binding 後的誤判，導致 Helper 抓錯 Index 的資料
            ModelState.Clear();
            return View(vm);
        }
    }
}
