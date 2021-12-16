using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Shipper
    {
        public string ShipperID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DeliveryUnitID { get; set; }
        public virtual DeliveryUni DeliveryUni { get; set; }
        public virtual List<ShipperOrder> ShipperOrders { get; set; }
    }
}
