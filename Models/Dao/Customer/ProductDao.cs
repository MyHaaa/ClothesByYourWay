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
        public List<Product> GetProducts(string keyword) => db.Products.Where(x => x.ProductName.Contains(keyword) || x.Description.Contains(keyword)).ToList();
        public List<Product> GetProductsSortByNew() => db.Products.OrderBy(x => x.CreatedDate).ToList();
        public List<Product> GetProductsSortByMostSale() => db.Products.OrderBy(x => x.OrderDetails.Count).ToList();
        public List<Product> GetProducts(double range)
        {
            var convertedRange = decimal.Parse(range.ToString());
            if (range == 500)
            {
                return db.Products.Where(x => x.Prices.FirstOrDefault().RetailPrice >= 500).ToList();
            }
            return db.Products.Where(x => (x.Prices.FirstOrDefault().RetailPrice >= convertedRange) && (x.Prices.FirstOrDefault().RetailPrice <= (convertedRange + 50))).ToList();
        }
    }
}
