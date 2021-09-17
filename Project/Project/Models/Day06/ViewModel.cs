using System;

namespace Project.Models.Day06
{
    public class ViewModel
    {
        public DateTime? OrderDate { get; set; }

        public OrderItem[] Items { get; set; }
    }
}
