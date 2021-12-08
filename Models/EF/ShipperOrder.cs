using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Models.EF
{
    public partial class ShipperOrder
    {
        public int ShipperOrderID { get; set; }

        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string EmployeeID { get; set; }

        [StringLength(50)]
        public string ShipperID { get; set; }

        public DateTime? DeliveryDatetime { get; set; }

        [StringLength(500)]
        public string DeliveryNote { get; set; }

        public virtual Order Order { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
