using System.ComponentModel.DataAnnotations;

namespace Project.Models.Day10
{
    public class Address
    {
        /// <summary>
        /// 縣市
        /// </summary>
        [Display(Name = "縣市")]
        public string City { get; set; }

        /// <summary>
        /// 鄉鎮
        /// </summary>
        [Display(Name = "鄉鎮")]
        public string TownShip { get; set; }

        /// <summary>
        /// 詳細
        /// </summary>
        [Display(Name = "詳細")]
        public string Detail { get; set; }
    }
}
