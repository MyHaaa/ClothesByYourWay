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
        public string GenerateOrderID(string customerID, string addressShip, string note)
        {
            var guid = (new Guid()).ToString();
            while(db.Orders.Where(x => x.OrderID== guid).FirstOrDefault() != null)
            {
                guid = (new Guid()).ToString();
            }
            return guid;
        }
    }
}
