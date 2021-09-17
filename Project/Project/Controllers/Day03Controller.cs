using Microsoft.AspNetCore.Mvc;
using Project.Models.Day03;

namespace Project.Controllers
{
    public class Day03Controller : Controller
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
        public IActionResult Case01([FromForm]ViewModel01 vm)
        {
            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Case02()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case02([FromForm]ViewModel02 vm)
        {
            return Ok(vm);
        }
    }
}
