namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        [StringLength(50)]
        public string EmployeeID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(25)]
        public string Password { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Required(ErrorMessage = "Vui lòng nhập Ngày Sinh")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(25)]
        public string CitizenID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserGroupID { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public DateTime? CreateDated { get; set; }

        public bool Status { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid? ActivationCode { get; set; }

        [StringLength(100)]
        public string ResetPasswordCode { get; set; }


        public virtual UserGroup UserGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
