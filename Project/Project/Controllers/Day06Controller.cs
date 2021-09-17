using Microsoft.AspNetCore.Mvc;
using Project.Models.Day06;

namespace Project.Controllers
{
    public class Day06Controller : Controller
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
            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Case02()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Case03()
        {
            return View();
        }
    }
}
