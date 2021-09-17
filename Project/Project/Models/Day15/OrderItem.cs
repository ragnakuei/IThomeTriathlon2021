using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day15
{
    /// <summary>
    /// 訂單項目
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 名稱
        /// </summary>
        [Display(Name = "名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Name = "數量")]
        public int? Quantity { get; set; }
    }
}
