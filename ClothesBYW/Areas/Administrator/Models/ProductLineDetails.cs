using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class ProductLineDetails
    {
        public ProductLine ProductLine { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public ProductImage ProductImage { get; set; }
        public List<PurchaseOrder> PurchaseOrder { get; set; }
    }
}