using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Promotion
    {
        public long PromotionID { get; set; }
        public string Description { get; set; }
        public decimal? PercentageDiscountSupplier { get; set; }
        public decimal? PercentageDiscountApproval { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual List<PromotionProduct> PromotionProducts { get; set; }
    }
}
