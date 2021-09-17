using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day10
{
    public class ViewModel02
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public Address Address { get; set; }
    }
}
