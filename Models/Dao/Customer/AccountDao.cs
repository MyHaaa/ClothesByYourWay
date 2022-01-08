using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Customer
{
    public class AccountDao
    {
        private ClothesBYWDbContext db = null;
        public AccountDao()
        {
            db = new ClothesBYWDbContext();
        }
        public EF.Customer UpdateInfo(string id, string name, string mobile, string email, string address)
        {
            var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if(customer != null)
            {
                customer.Name = name;
                customer.Phone = mobile;
                customer.Email = email;
                customer.Address = address;
                db.SaveChanges();
            }
            return customer;
        }
        public List<EF.Order> GetOrders(string userID)
        {
            return db.Orders.Where(x => x.CustomerID == userID).OrderByDescending(x => x.CreateDate).ToList();
        }
        public bool ChangePassword(string id, string oldPass, string newPass)
        {
            var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if (customer.Password != oldPass) return false;
            if (customer != null)
            {
                customer.Password = newPass;
                db.SaveChanges();
            }
            return true;
        }
    }
}
