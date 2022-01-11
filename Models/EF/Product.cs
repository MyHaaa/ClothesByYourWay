using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Product
    {
        [Display(Name = "Mã sản phẩm ")]
        public string ProductID { get; set; }

        [Display(Name = "Tên sản phẩm ")]
        public string ProductName { get; set; }

        [Display(Name = "Meta Keyword ")]
        public string MetaKeyword { get; set; }

        [Display(Name = "Mô tả ")]
        public string Description { get; set; }
        [Display(Name = "Ngày tạo ")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Tạo bởi ")]
        public string CreatedBy { get; set; }

        [Display(Name = "Mã loại sản phẩm ")]
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        [Display(Name = "Trạng thái ")]
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
