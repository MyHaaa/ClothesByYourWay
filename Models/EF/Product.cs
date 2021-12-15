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
            Prices = new HashSet<Price>();
            ProductLines = new HashSet<ProductLine>();
            ProductModifications = new HashSet<ProductModification>();
            PromotionProducts = new HashSet<PromotionProduct>();
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

        public int? CategoryID { get; set; }

        public int? BrandID { get; set; }

        public int? Status { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLine> ProductLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductModification> ProductModifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
    }
}
