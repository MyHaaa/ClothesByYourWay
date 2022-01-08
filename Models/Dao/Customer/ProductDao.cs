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
            var lsProduct = db.Products.ToList();
            var lsLine = db.ProductLines.OrderBy(x => x.OrderDetails.Count).ToList();
            var result = new List<Product>();
            foreach(var item in lsLine)
            {
                var prd = lsProduct.Where(x => x.ProductID == item.ProductID).FirstOrDefault();
                if (prd != null)
                {
                    result.Add(prd);
                    lsProduct.Remove(prd);
                }
            }
            return _FomatList(result);
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
            foreach (var item in product.ProductLines)
            {
                if(listColors.Where(x => x.ColorID == item.ColorID).FirstOrDefault() == null)
                {
                    listColors.Add(item.Color);
                }
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
                FeedbackCount = product.Feedbacks.Count,
                Description = product.Description,
                CategoryID = product.CategoryID,
                CategoryName = product.ProductCategory.Name
            };
        }

        public string GetProductLineIDWhenChangeValue(string currentLine, string value, bool isSize)
        {
            var line = db.ProductLines.Where(x => x.ProductLineID == currentLine).FirstOrDefault();
            ProductLine result = null;
            if (isSize)
            {
                result = db.ProductLines.Where(x => x.ProductID == line.ProductID && x.Size == value && x.ColorID == line.ColorID).FirstOrDefault();
            }
            else
            {
                result = db.ProductLines.Where(x => x.ProductID == line.ProductID && x.Color.ColorName == value && x.Size == line.Size).FirstOrDefault();
            }
            if(result == null)
            {
                return currentLine;
            }
            return result.ProductLineID;
        }
    }
}
