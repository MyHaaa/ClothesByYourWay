using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Customer
{
    public class UserDao
    {
        private ClothesBYWDbContext db = null;
        public UserDao()
        {
            db = new ClothesBYWDbContext();
        }
        public EF.Customer GetCustomer(string id) => db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
    }
}
