using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class ShipperOrder
    {
        public int ShipperOrderID { get; set; }
        public string OrderID { get; set; }
        public string EmployeeID { get; set; }
        public string ShipperID { get; set; }
        public DateTime? DeliveryDatetime { get; set; }
        public string DeliveryNote { get; set; }
        public virtual Order Order { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
