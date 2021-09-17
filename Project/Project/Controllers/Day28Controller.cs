using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day28;

namespace Project.Controllers
{
    public class Day28Controller : Controller
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

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult GetChildOptions([FromBody]int? id)
        {
            var result = _allOptions.Where(o => o.ParentValue == id).ToArray();

            return Ok(result);
        }

        private Option[] _allOptions
            = new Option[]
              {
                  new() { Value = 1, Text  = "1", ParentValue     = null },
                  new() { Value = 2, Text  = "1-1", ParentValue   = 1 },
                  new() { Value = 3, Text  = "1-1-1", ParentValue = 2 },
                  new() { Value = 4, Text  = "1-1-2", ParentValue = 2 },
                  new() { Value = 5, Text  = "1-1-3", ParentValue = 2 },
                  new() { Value = 6, Text  = "1-1-4", ParentValue = 2 },
                  new() { Value = 7, Text  = "1-2", ParentValue   = 1 },
                  new() { Value = 8, Text  = "1-2-1", ParentValue = 7 },
                  new() { Value = 9, Text  = "1-2-2", ParentValue = 7 },
                  new() { Value = 10, Text = "1-2-3", ParentValue = 7 },
                  new() { Value = 11, Text = "1-2-4", ParentValue = 7 },
                  new() { Value = 12, Text = "2", ParentValue     = null },
                  new() { Value = 13, Text = "2-1", ParentValue   = 12 },
                  new() { Value = 14, Text = "2-1-1", ParentValue = 13 },
                  new() { Value = 15, Text = "2-1-2", ParentValue = 13 },
                  new() { Value = 16, Text = "2-1-3", ParentValue = 13 },
                  new() { Value = 17, Text = "2-1-4", ParentValue = 13 },
                  new() { Value = 18, Text = "2-2", ParentValue   = 12 },
                  new() { Value = 19, Text = "2-2-1", ParentValue = 18 },
                  new() { Value = 20, Text = "2-2-2", ParentValue = 18 },
                  new() { Value = 21, Text = "2-2-3", ParentValue = 18 },
                  new() { Value = 22, Text = "2-2-4", ParentValue = 18 },
                  new() { Value = 23, Text = "3", ParentValue     = null },
                  new() { Value = 24, Text = "3-1", ParentValue   = 23 },
                  new() { Value = 25, Text = "3-1-1", ParentValue = 24 },
                  new() { Value = 26, Text = "3-1-2", ParentValue = 24 },
                  new() { Value = 27, Text = "3-1-3", ParentValue = 24 },
                  new() { Value = 28, Text = "3-1-4", ParentValue = 24 },
                  new() { Value = 29, Text = "3-2", ParentValue   = 23 },
                  new() { Value = 30, Text = "3-2-1", ParentValue = 29 },
                  new() { Value = 31, Text = "3-2-2", ParentValue = 29 },
                  new() { Value = 32, Text = "3-2-3", ParentValue = 29 },
                  new() { Value = 33, Text = "3-2-4", ParentValue = 29 },
              };
    }
}
