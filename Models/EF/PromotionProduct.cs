using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class PromotionProduct
    {
        public long PromotionProductID { get; set; }
        public long PromotionID { get; set; }
        public string ProductID { get; set; }
        public decimal? EachPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
