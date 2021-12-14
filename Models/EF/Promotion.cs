namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            PromotionProducts = new HashSet<PromotionProduct>();
        }

        public long PromotionID { get; set; }

        public string Description { get; set; }

        [Display(Name = "Chiết khấu phần trăm từ nhà phân phối")]
        public decimal? PercentageDiscountSupplier { get; set; }

        [Display(Name = "Chiết khấu phần trăm được phê duyệt")]
        public decimal? PercentageDiscountApproval { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }
        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
    }
}
