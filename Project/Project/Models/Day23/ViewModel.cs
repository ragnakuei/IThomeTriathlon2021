using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day23
{
    public class ViewModel
    {
        [Display(Name                   = "訂單日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "訂單項目")]
        public OrderItem[] Items { get; set; }

        [Display(Name = "小計")]
        public decimal? SubTotalAmount { get; set; }

        [Display(Name = "稅金")]
        public decimal? Tax { get; set; }

        [Display(Name = "總計")]
        public decimal? TotalAmount { get; set; }
    }
}
