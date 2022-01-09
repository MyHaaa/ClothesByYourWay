using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SupplierDao
    {
        private ClothesBYWDbContext db = null;

        public SupplierDao()
        {
            db = new ClothesBYWDbContext();
        }

        public void Insert(Supplier entity)
        {
            entity.SupplierID = db.Suppliers.Count() + 1;

            db.Suppliers.Add(entity);
            db.SaveChanges();
        }

        public void Update(Supplier entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Supplier ViewDetail(string SupplierID)
        {
            return db.Suppliers.Find(SupplierID); //đây là phương thức tìm kiếm bằng khóa chính
        }

        public Supplier GetByName(string name)
        {
            return db.Suppliers.SingleOrDefault(x => x.Name == name);
        }
        public Supplier GetByID(int id)
        {
            return db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault<Supplier>();
        }
        public void Delete(int id)
        {
            Supplier mau = db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault<Supplier>();
            db.Suppliers.Remove(mau);
            db.SaveChanges();
        }
        public int ProductCount(int id)
        {
            List<ProductLine> productLines = db.ProductLines.Where(x => x.SupplierID == id).ToList();
            return productLines.Count();
        }
    }
}
