using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string MeteKeyword { get; set; }
        public bool? Status { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
