using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day29;

namespace Project.Controllers
{
    public class Day29Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            return View(new ViewModel());
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult PostCase01([FromBody]ViewModel vm)
        {
            return Ok(vm);
        }
    }
}
