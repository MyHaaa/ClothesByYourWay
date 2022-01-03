using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Customer
{
    public class OrderDao
    {
        private ClothesBYWDbContext db = null;
        public OrderDao()
        {
            db = new ClothesBYWDbContext();
        }
        public string CreateOrder(string customerID, List<OrderDetail> items)
        {
            var cus = db.Customers.Where(x => x.CustomerID == customerID).FirstOrDefault();
            var orderID = (Guid.NewGuid()).ToString();
            while(db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault()!= null)
            {
                orderID = (Guid.NewGuid()).ToString();
            }
            var order = new Order()
            {
                OrderID = orderID,
                CustomerID = customerID,
                AddressShip = cus.Address,
                CreateDate = DateTime.Now,
                Status = 1, // COD
                Total = items.Sum(x => x.PriceEach * x.QuantitySold),
                VoucherID = "VOUCHERD"
            };
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }
        public void AddOrderItems(string orderID, List<OrderDetail> items)
        {
            foreach (var item in items)
            {
                var detailID = (Guid.NewGuid()).ToString();
                while (db.OrderDetails.Where(x => x.OrderDetailID == detailID).FirstOrDefault() != null)
                {
                    detailID = (Guid.NewGuid()).ToString();
                }
                item.OrderID = orderID;
                item.OrderDetailID = detailID;
                db.OrderDetails.Add(item);
            }
            db.SaveChanges();
        }
    }
}
