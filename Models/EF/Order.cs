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
        public string EmployeeID { get; set; }

        [StringLength(50)]
        public string ShipperID { get; set; }

        public DateTime? DeliveryDatetime { get; set; }

        [StringLength(500)]
        public string DeliveryNote { get; set; }

        [StringLength(50)]
        public string VoucherID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Shipper Shipper { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
