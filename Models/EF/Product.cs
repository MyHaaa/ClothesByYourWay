namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
            Prices = new HashSet<Price>();
            ProductImages = new HashSet<ProductImage>();
            ProductModifications = new HashSet<ProductModification>();
            PromotionProducts = new HashSet<PromotionProduct>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }


        [StringLength(50)]
        public string ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm!")]
        [StringLength(500)]
        public string ProductName { get; set; }

        [Display(Name = "Meta Keyword")]
        [Required(ErrorMessage = "Bạn chưa nhập meta keyword!")]
        [StringLength(150)]
        public string MetaKeyword { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public int? Status { get; set; }

        [Display(Name = "Kích thước")]
        [Required(ErrorMessage = "Bạn chưa nhập kích thước!")]
        [StringLength(5)]
        public string Size { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int? SupplierID { get; set; }

        [Display(Name = "Màu sắc")]
        public int? ColorID { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int? CategoryID { get; set; }

        [Display(Name = "Thương hiệu")]
        public int? BrandID { get; set; }

        [Display(Name = "Số lượng tồn kho")]
        public long QuantityInStock { get; set; }

        [Display(Name = "Số lượng tồn kho thấp nhất cho phép")]
        public int? MinimumQuantityAvailable { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductModification> ProductModifications { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
