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
    public class CustomerCategoryDao
    {
        private ClothesBYWDbContext db = null;

        public CustomerCategoryDao()
        {
            db = new ClothesBYWDbContext();
        }

        public void Insert(CustomerCategory entity)
        {

            db.CustomerCategories.Add(entity);
            db.SaveChanges();
        }

        public void Update(CustomerCategory entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public CustomerCategory ViewDetail(string CustomerCategoryID)
        {
            return db.CustomerCategories.Find(CustomerCategoryID); //đây là phương thức tìm kiếm bằng khóa chính
        }

        public CustomerCategory GetByName(string name)
        {
            return db.CustomerCategories.SingleOrDefault(x => x.Name == name);
        }
        public CustomerCategory GetByID(int id)
        {
            return db.CustomerCategories.Where(x => x.CustomerCategoryID == id).FirstOrDefault<CustomerCategory>();
        }
        public void Delete(int id)
        {
            CustomerCategory mau = db.CustomerCategories.Where(x => x.CustomerCategoryID == id).FirstOrDefault<CustomerCategory>();
            db.CustomerCategories.Remove(mau);
            db.SaveChanges();
        }

        public CustomerCategory NameCount(string name)
        {
            return db.CustomerCategories.Where(x => x.Name == name).SingleOrDefault();
        }
    }
}
