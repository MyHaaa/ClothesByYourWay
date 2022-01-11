using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Price
    {
        [Display(Name = "Mã Price ")]
        public int PriceID { get; set; }

        [Display(Name = "Mã sản phẩm ")]
        public string ProductID { get; set; }

        [Display(Name = "Giá bán sỉ ")]
        public decimal? WholeSalePrice { get; set; }

        [Display(Name = "Giá bán lẻ ")]
        public decimal? RetailPrice { get; set; }

        [Display(Name = "Giá sàn ")]
        public decimal? StandardPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
