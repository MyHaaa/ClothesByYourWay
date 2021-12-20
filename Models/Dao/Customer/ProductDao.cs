using Models.EF;
using Models.ViewModels.Customer.Product;
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
        // Multiple Products
        public List<Product> GetProducts()
        {
            return _FomatList(db.Products.Where(x => x.ProductLines.Count>0).ToList());
        }
        public List<ProductCategory> GetCategories() => db.ProductCategories.ToList();
        public List<Product> GetProducts(int cateID) 
        { 
            return _FomatList(db.Products.Where(x => x.ProductLines.Count > 0 && x.CategoryID == cateID).ToList());
        }
        public List<Product> GetProducts(string keyword)
        {
            return _FomatList(db.Products.Where(x => x.ProductLines.Count > 0 && (x.ProductName.Contains(keyword) || x.Description.Contains(keyword))).ToList());
        }
        public List<Product> GetProductsSortByNew()
        {
            return _FomatList(db.Products.Where(x => x.ProductLines.Count > 0).OrderBy(x => x.CreatedDate).ToList());
        }
        public List<Product> GetProductsSortByMostSale()
        {
            return new List<Product>();
            //db.Products.OrderBy(x => x.OrderDetails.Count).ToList();
        }
        public List<Product> GetProducts(double range)
        {
            var convertedRange = decimal.Parse(range.ToString());
            var list = new List<Product>();
            if (range == 500)
            {
                return _FomatList(db.Products.Where(x => x.ProductLines.Count > 0 && x.Prices.FirstOrDefault().RetailPrice >= 500).ToList());
            }
            else
            {
                return _FomatList(db.Products.Where(x => x.ProductLines.Count > 0 && 
                x.Prices.FirstOrDefault().RetailPrice >= convertedRange && 
                x.Prices.FirstOrDefault().RetailPrice <= (convertedRange + 50)).ToList());
            }
        }

        private List<Product> _FomatList(List<Product> list)
        {
            foreach (var item in list)
            {
                var image = item.ProductLines.FirstOrDefault().ProductImages.FirstOrDefault();
                if (image != null)
                {
                    item.MetaKeyword = image.ImageLink;
                }
                else
                {
                    item.MetaKeyword = "/Assets/Client/img/Product/12-2.png";
                }
            }
            return list;
        }

        // Single Product
        public ProductDetailModel GetProductDetail(string id)
        {
            var line = db.ProductLines.Where(x => x.ProductLineID == id).FirstOrDefault();
            var product = db.Products.Where(x => x.ProductID == line.ProductID).FirstOrDefault();
            var listColors = new List<Color>();
            var hashIDLine = new List<Tuple<int, string>>();
            foreach (var item in product.ProductLines)
            {
                if(listColors.Where(x => x.ColorID == item.ColorID).FirstOrDefault() == null)
                {
                    listColors.Add(item.Color);
                }
                hashIDLine.Add(new Tuple<int, string>(item.ColorID, item.ProductLineID));
            }
            return new ProductDetailModel()
            {
                ProductLineID = line.ProductLineID,
                ProductID = line.ProductID,
                Size = line.Size,
                ColorID = line.ColorID,
                QuantityInStock = line.QuantityInStock,
                Name = product.ProductName,
                ProductImages = line.ProductImages.ToList(),
                RetailPrice = product.Prices.FirstOrDefault().RetailPrice,
                StandardPrice = product.Prices.FirstOrDefault().StandardPrice,
                Sizes = product.ProductLines.Select(x => x.Size).Distinct().ToList(),
                Colors = listColors,
                ListIDColor_Line = hashIDLine,
                FeedbackCount = product.Feedbacks.Count,
                Description = product.Description,
                CategoryID = product.CategoryID,
                CategoryName = product.ProductCategory.Name
            };
        }
    }
}
