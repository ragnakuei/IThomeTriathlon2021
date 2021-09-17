using System;

namespace Project.Models.Day19
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
        public string[] Items { get; set; }
    }
}
