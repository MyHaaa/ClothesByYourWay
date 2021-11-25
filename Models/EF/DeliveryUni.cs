namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliveryUni
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryUni()
        {
            Shippers = new HashSet<Shipper>();
        }

        [Key]
        public int DeliveryUnitID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(250)]
        public string ContactPerson { get; set; }

        [StringLength(15)]
        public string PhoneContactPerson { get; set; }

        [StringLength(100)]
        public string EmailContactPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipper> Shippers { get; set; }
    }
}
