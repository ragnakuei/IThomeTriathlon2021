using System;
using System.Collections.Generic;

namespace Project.Models.Day05
{
    public class ViewModel
    {
        public DateTime? OrderDate { get; set; }

        public ICollection<string> Items { get; set; }
    }
}
