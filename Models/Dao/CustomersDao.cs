using Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CustomersDao
    {
        private ClothesBYWDbContext db = null;


        public CustomersDao()
        {
            db = new ClothesBYWDbContext();
        }


        public void Update(EF.Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public EF.Customer ViewDetail(string CustomerID)
        {
            return db.Customers.Find(CustomerID); //đây là phương thức tìm kiếm bằng khóa chính
        }

        public EF.Customer GetByName(string name)
        {
            return db.Customers.SingleOrDefault(x => x.Name == name);
        }
        public EF.Customer GetByID(string id)
        {
            return db.Customers.Where(x => x.CustomerID == id).FirstOrDefault<EF.Customer>();
        }
    }
}
