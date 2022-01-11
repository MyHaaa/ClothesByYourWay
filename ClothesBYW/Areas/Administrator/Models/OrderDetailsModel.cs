using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class OrderDetailsModel
    {
        public Order order { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }
        public IEnumerable<ShipperOrder> shipperOrders { get; set; }
        public IEnumerable<ShipperOrder> shipperOrder { get; set; }

    }
}