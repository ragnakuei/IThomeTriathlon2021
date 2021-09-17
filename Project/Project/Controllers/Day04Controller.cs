using Microsoft.AspNetCore.Mvc;
using Project.Models.Day05;

namespace Project.Controllers
{
    public class Day04Controller : Controller
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
        public IActionResult Case01([FromForm]string[] strs)
        {
            return Ok(strs);
        }
    }
}
