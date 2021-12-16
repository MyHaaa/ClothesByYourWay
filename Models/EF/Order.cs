using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Order
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string AddressShip { get; set; }
        public decimal? Total { get; set; }
        public string Note { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public string VoucherID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ShipperOrder> ShipperOrders { get; set; }
    }
}
