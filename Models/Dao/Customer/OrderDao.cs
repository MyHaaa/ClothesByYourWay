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
        public string CreateOrder(string customerID, List<OrderDetail> items, decimal? total, string voucher)
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
                Total = total,
                VoucherID = voucher
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

                var line = db.ProductLines.Where(x => x.ProductLineID == item.ProductLineID).FirstOrDefault();
                line.QuantityInStock = line.QuantityInStock - (long)item.QuantitySold;
            }
            
            db.SaveChanges();
        }
        public void UpdateQuantity(List<OrderDetail> items)
        {
            foreach (var item in items)
            {
                var line = db.ProductLines.Where(x => x.ProductLineID == item.ProductLineID).FirstOrDefault();
                line.QuantityInStock = line.QuantityInStock - (long)item.QuantitySold;
            }
            db.SaveChanges();
        }
        public Voucher CheckVoucher(string id)
        {
            var check = db.Vouchers.Where(x => x.VoucherID == id && x.EndDate >= DateTime.Now && x.VoucherID != "").FirstOrDefault();
            return check;
        }
    }
}
