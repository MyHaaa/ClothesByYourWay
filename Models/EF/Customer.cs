namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        [StringLength(50)]
        public string CustomerID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Username { get; set; }

        [StringLength(25)]
        public string Password { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public DateTime? CreateDated { get; set; }

        public bool Status { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public int CustomerCatergoryID { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid ActivationCode { get; set; }

        [StringLength(100)]
        public string ResetPasswordCode { get; set; }

        public virtual CustomerCategory CustomerCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
