﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day11
{
    public class ViewModel
    {
        [Display(Name                   = "訂單日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "訂單項目")]
        public string[] Items { get; set; }
    }
}