using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Customer
{
    public class ProductDao
    {
        private ClothesBYWDbContext db = null;
        public ProductDao()
        {
            db = new ClothesBYWDbContext();
        }
        public List<Product> GetProducts() => db.Products.ToList();
        public List<ProductCategory> GetCategories() => db.ProductCategories.ToList();
        public List<Product> GetProducts(int cateID) => db.Products.Where(x => x.CategoryID == cateID).ToList();
        public Product GetProductDetail(string id) => db.Products.Where(x => x.ProductID == id).FirstOrDefault();
    }
}
