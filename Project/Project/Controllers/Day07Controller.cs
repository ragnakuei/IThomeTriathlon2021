using Microsoft.AspNetCore.Mvc;
using Project.Models.Day07;

namespace Project.Controllers
{
    public class Day07Controller : Controller
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
        public IActionResult Case02([FromForm]ViewModel02 vm)
        {
            return View(vm);
        }
    }
}
