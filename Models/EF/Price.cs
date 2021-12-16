using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Price
    {
        public int PriceID { get; set; }
        public string ProductID { get; set; }
        public decimal? WholeSalePrice { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? StandardPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
