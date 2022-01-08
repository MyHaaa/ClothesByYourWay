using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Models.EF;

namespace Models.Dao
{
    public class ProductDao
    {
        private ClothesBYWDbContext db = null;
        public ProductDao()
        {
            db = new ClothesBYWDbContext();
        }

        public List<Product> GetProducts()
        {
            return db.Products.Include(p => p.Brand).Include(p => p.ProductCategory).ToList();
        }

        public Product GetProduct(string productID) => db.Products.Where(x => x.ProductID == productID).FirstOrDefault();

        public void SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteProduct(string productID)
        {
            var product = db.Products.Find(productID);

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void SaveProductModification(string productID, string username, string note)
        {
            var modified = new ProductModification();
            modified.ModifiledBy = username;
            modified.ProductID = productID;
            modified.ModifiledDate = DateTime.Now;
            modified.Note = note;
            db.ProductModifications.Add(modified);
            db.SaveChanges();
        }

        public List<ProductModification> GetProductModification(string productID)
        {
            return db.ProductModifications.Where(x => x.ProductID == productID).ToList();
        }

        public List<Price> GetProductPrices(string productID)
        {
            return db.Prices.Where(x => x.ProductID == productID).ToList();
        }

        public void SaveProductPrices(Price price)
        {
            db.Prices.Add(price);
            db.SaveChanges();
        }

        public void UpdateProductPrices(Price price)
        {
            db.Entry(price).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
