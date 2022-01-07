using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class ProductDetails
    {
        public Product Product { get; set; }
        public List<Price> Price { get; set; }
        public List<ProductLine> ProductLine { get; set; }
        public List<ProductModification> ProductModification { get; set; }
        public List<PromotionProduct> PromotionProducts { get; set; }
    }
}