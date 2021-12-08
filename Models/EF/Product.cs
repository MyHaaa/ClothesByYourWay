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
            PromotionProducts = new HashSet<PromotionProduct>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        [StringLength(150)]
        public string MetaKeyword { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        [StringLength(25)]
        public string ModifiledBy { get; set; }

        public int? Status { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        public int? ColorID { get; set; }

        public int? CategoryID { get; set; }

        public long? PromotionID { get; set; }

        public int? BrandID { get; set; }

        public long? QuantityInStock { get; set; }

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
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
