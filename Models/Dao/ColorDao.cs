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
    public class ColorDao
    {
        private ClothesBYWDbContext db = null;

        public ColorDao()
        {
            db = new ClothesBYWDbContext();
        }

        public void Insert(Color entity)
        {
            entity.ColorID = db.Colors.Count() + 1;

            db.Colors.Add(entity);
            db.SaveChanges();
        }

        public void Update(Color entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Color ViewDetail(string colorID)
        {
            return db.Colors.Find(colorID); //đây là phương thức tìm kiếm bằng khóa chính
        }

        public Color GetByName(string name)
        {
            return db.Colors.SingleOrDefault(x => x.ColorName == name);
        }
        public Color GetByID(int id)
        {
            return db.Colors.Where(x => x.ColorID == id).FirstOrDefault<Color>();
        }
        public void Delete(int id)
        {
            Color mau = db.Colors.Where(x => x.ColorID == id).FirstOrDefault<Color>();
            db.Colors.Remove(mau);
            db.SaveChanges();
        }
        public int ProductCount(int id)
        {
            List<ProductLine> productLines = db.ProductLines.Where(x => x.ColorID == id).ToList();
            return productLines.Count();
        }
    }
}
