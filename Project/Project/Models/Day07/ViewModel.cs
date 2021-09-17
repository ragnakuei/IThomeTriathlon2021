using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day07
{
    public class ViewModel
    {
        [Display(Name = "編號")]
        public int? Id { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }
    }
}
