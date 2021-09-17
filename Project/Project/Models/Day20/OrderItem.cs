using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day20
{
    /// <summary>
    /// 訂單項目
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int? Quantity { get; set; }
    }
}
