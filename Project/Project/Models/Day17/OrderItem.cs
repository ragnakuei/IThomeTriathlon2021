using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day17
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
        /// 單價
        /// </summary>
        [Display(Name = "單價")]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Name = "數量")]
        public int? Quantity { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [Display(Name = "金額")]
        public decimal? Amount { get; set; }
    }
}
