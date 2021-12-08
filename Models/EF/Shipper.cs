namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            ShipperOrders = new HashSet<ShipperOrder>();
        }

        [StringLength(50)]
        public string ShipperID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public int? DeliveryUnitID { get; set; }

        public virtual DeliveryUni DeliveryUni { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipperOrder> ShipperOrders { get; set; }
    }
}

