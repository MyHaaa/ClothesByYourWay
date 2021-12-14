using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CustomerDao
    {
        private ClothesBYWDbContext db = null;
        public CustomerDao()
        {
            db = new ClothesBYWDbContext();
        }
        public int Login(string email, string password)
        {
            var result = db.Customers.SingleOrDefault(x => x.Email == email || x.Username == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public EF.Customer GetCustomer(string email)
        {
            return db.Customers.SingleOrDefault(x => x.Email == email || x.Username == email);
        }
        public int Regist(string name, string email, string phone, string password)
        {
            var result = db.Customers.SingleOrDefault(x => x.Email == email);
            if (result != null)
            {
                return -1;
            }
            var sampleGuid = Guid.NewGuid().ToString();
            while(db.Customers.Where(x => x.CustomerID == sampleGuid).FirstOrDefault()!= null)
            {
                sampleGuid = Guid.NewGuid().ToString();
            }
            db.Customers.Add(new EF.Customer()
            {
                CustomerID = sampleGuid,
                Name = name,
                Username = email,
                Password = password,
                Phone = phone,
                Email = email,
                CreateDated = DateTime.Now,
                Status = true,
                ModifiledDate = DateTime.Now,
                CustomerCatergoryID = 1
            });
            db.SaveChanges();
            return 1;
        }
    }
}
