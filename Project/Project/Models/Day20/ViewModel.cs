using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day20
{
    public class ViewModel
    {
        /// <summary>
        /// 訂單日期
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 訂單項目
        /// </summary>
        public OrderItem[] Items { get; set; }
    }
}
