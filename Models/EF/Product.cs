using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string MetaKeyword { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int? Status { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
        public virtual List<ProductModification> ProductModifications { get; set; }
        public virtual List<PromotionProduct> PromotionProducts { get; set; }
    }
}
