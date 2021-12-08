namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ShipperOrders = new HashSet<ShipperOrder>();
        }


        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string CustomerID { get; set; }

        public string AddressShip { get; set; }

        public decimal? Total { get; set; }

        public string Note { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string VoucherID { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Voucher Voucher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipperOrder> ShipperOrders { get; set; }
    }
}
