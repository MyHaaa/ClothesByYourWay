using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public string ImageBrand { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
