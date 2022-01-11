using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class ProductCategory
    {
        [Display(Name = "Mã loại sản phẩm ")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Tên loài sản phẩm ")]
        public string Name { get; set; }

        [Display(Name = "Meta Keyword ")]
        public string MeteKeyword { get; set; }

        [Display(Name = "Trạng thái ")]
        public bool? Status { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
