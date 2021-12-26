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
        public bool CreateOrder(string customerID, List<OrderDetail> items)
        {
            var cus = db.Customers.Where(x => x.CustomerID == customerID).FirstOrDefault();
            var order = new Order()
            {
                CustomerID = customerID,
                AddressShip = cus.Address,
                CreateDate = DateTime.Now,
                Status = 1, // COD
                Total = items.Sum(x => x.PriceEach * x.QuantitySold)
            };
            db.Orders.Add(order);
            foreach(var item in items)
            {
                item.OrderID = order.OrderID;
                db.OrderDetails.Add(item);
            }
            db.SaveChanges();
            return true;
        }
    }
}
