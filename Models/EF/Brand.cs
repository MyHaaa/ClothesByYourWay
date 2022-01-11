using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Brand
    {
        [Display(Name = "Mã thương hiệu")]
        public int BrandID { get; set; }

        [Display(Name = "Tên thương hiệu")]
        public string BrandName { get; set; }

        [Display(Name = "Logo thương hiệu")]
        public string ImageBrand { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
