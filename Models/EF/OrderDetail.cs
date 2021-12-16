using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class OrderDetail
    {
        public string OrderDetailID { get; set; }
        public string OrderID { get; set; }
        public decimal? PriceEach { get; set; }
        public string ProductLineID { get; set; }
        public int? QuantitySold { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductLine ProductLine { get; set; }
    }
}
