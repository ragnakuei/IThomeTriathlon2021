using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day19;

namespace Project.Controllers
{
    public class Day19Controller : Controller
    {
        [HttpGet]
        public IActionResult Case01()
        {
            var vm = new ViewModel
                     {
                         OrderDate = null,
                         Items     = Enumerable.Repeat(string.Empty, 3).ToArray(),
                     };

            return View(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PostCase01([FromBody]ViewModel vm)
        {
            return Ok(vm);
        }
    }
}
