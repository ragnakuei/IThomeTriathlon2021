using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class Day02Controller : Controller
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
        public IActionResult Case01([FromForm]int id)
        {
            return Ok(id);
        }

        [HttpGet]
        public IActionResult Case02()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Case02([FromForm]int id, [FromForm]string name)
        {
            return Ok(new { id, name });
        }
    }
}
