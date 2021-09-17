using Microsoft.AspNetCore.Mvc;
using Project.Models.Day18;

namespace Project.Controllers
{
    public class Day18Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            return View(new ViewModel());
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PostCase01([FromBody]ViewModel vm)
        {
            return Ok(vm);
        }
    }
}
