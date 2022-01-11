using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class OrderDetail
    {
        public string OrderDetailID { get; set; }
        [Display(Name = "Mã đơn hàng ")]
        public string OrderID { get; set; }
        [Display(Name = "Đơn giá ")]
        public decimal? PriceEach { get; set; }
        [Display(Name = "Mã dòng sản phẩm ")]
        public string ProductLineID { get; set; }
        [Display(Name = "Số lượng mua ")]
        public int? QuantitySold { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductLine ProductLine { get; set; }
    }
}
