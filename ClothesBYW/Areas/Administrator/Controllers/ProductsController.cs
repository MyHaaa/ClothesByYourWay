using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Areas.Administrator.Models;
using ClothesBYW.Common;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDao dao = new ProductDao();
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // Danh sách product (trang quản lý)
        public ActionResult Index()
        {
            Session[CC.PRODUCT_SESSION] = null;
            var products = db.Products.Include(p => p.Brand).Include(p => p.ProductCategory);
            return View(products.ToList());
        }

        //Chi tiết product
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var productSession = new ProductModel();
            productSession.ProductID = product.ProductID;

            Session.Add(CC.PRODUCT_SESSION, productSession);
            Session["PRODUCT_SESSION"] = productSession.ProductID;

            List<ProductModification> productModificationsList = db.ProductModifications.Where(pm => pm.ProductID == id).ToList();
            List<ProductLine> productLineList = db.ProductLines.Where(pi => pi.ProductID == id).ToList();
            List<Price> pricesList = db.Prices.Where(p => p.ProductID == id).OrderByDescending(x => x.PriceID).Take(1).ToList();
            List<PromotionProduct> promotionProductsList = db.PromotionProducts.Where(p => p.ProductID == id).OrderByDescending(x => x.PromotionID).Skip(1).ToList();

            List<PromotionProduct> promotionProducts = db.PromotionProducts.Where(p => p.ProductID == id).OrderByDescending(x => x.PromotionID).Take(1).ToList();
            ViewBag.promotionProducts = promotionProducts;

            ProductDetails productDetails = new ProductDetails();
            productDetails.Product = product;
            productDetails.ProductModification = productModificationsList;
            productDetails.ProductLine = productLineList;
            productDetails.Price = pricesList;
            productDetails.PromotionProducts = promotionProductsList;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        //Tạo mới product
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,MetaKeyword,Description,CreatedDate,CreatedBy,Status,Size,SupplierID,ColorID,CategoryID,BrandID,QuantityInStock,MinimumQuantityAvailable")] Product product)
        {
            if (ModelState.IsValid)
            {
                string username = Session["Username"].ToString();
                string count = db.Products.Count().ToString();
                product.CreatedBy = username;
                product.ProductID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + count;
                product.CreatedDate = DateTime.Now;
                product.Status = 1;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", product.CategoryID);
            return View(product);
        }

        //Chỉnh sửa thông tin product
        public ActionResult EditInfor(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", product.CategoryID);
            return PartialView(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfor([Bind(Include = "ProductID,ProductName,MetaKeyword,Description,CreatedDate,CreatedBy,Status,Size,SupplierID,ColorID,CategoryID,BrandID,QuantityInStock,MinimumQuantityAvailable")] Product product)
        {
            if (ModelState.IsValid)
            {
                string username = Session["Username"].ToString();
                db.Entry(product).State = EntityState.Modified;
                dao.SaveProductModification(product.ProductID, username, "Cập nhật thông tin sản phẩm");
                db.SaveChanges();
                return RedirectToAction("Details", new { id = product.ProductID });
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", product.CategoryID);
            return PartialView(product);
        }

        //Sửa giá sản phẩm
        public ActionResult EditPrice(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Price> pricesList = db.Prices.Where(p => p.ProductID == id).OrderByDescending(x => x.PriceID).Take(1).ToList();
            Price price = pricesList[0];
            if (price == null)
            {
                return HttpNotFound();
            }
            return PartialView(price);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrice([Bind(Include = "PriceID,ProductID,WholeSalePrice,RetailPrice,StandardPrice")] Price price)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(price).State = EntityState.Modified;
                string username = Session["Username"].ToString();
                db.Prices.Add(price);
                dao.SaveProductModification(price.ProductID, username, "Cập nhật giá cả sản phẩm");
                db.SaveChanges();
                return RedirectToAction("Details", new { id = price.ProductID });
            }
            return PartialView(price);
        }


        // GET: Administrator/Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administrator/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Thêm dòng sản phẩm
        public ActionResult AddProductLine()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProductLine([Bind(Include = "ProductLineID,ProductID,Alias,Status,Size,MinimumQuantityAvailable,SupplierID,ColorID,QuantityInStock,CreatedBy,CreatedDate")] ProductLine productLine)
        {
            if (ModelState.IsValid)
            {
                string username = Session["Username"].ToString();
                string productID = Session["PRODUCT_SESSION"].ToString();
                string count = (db.ProductLines.Where(x => x.ProductID == productID).Count() + 1).ToString();

                productLine.CreatedBy = username;
                productLine.ProductLineID = productID + "_" + count;
                productLine.CreatedDate = DateTime.Now;
                productLine.ProductID = productID;

                db.ProductLines.Add(productLine);
                dao.SaveProductModification(productID, username, "Thêm dòng sản phẩm mới" + productLine.ProductLineID);
                db.SaveChanges();
                return RedirectToAction("DetailsProductLine", new { id = productLine.ProductLineID });
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productLine.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productLine.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", productLine.SupplierID);
            return PartialView(productLine);
        }

        //Chi tiết dòng sản phẩm
        public ActionResult DetailsProductLine(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLine productLine = db.ProductLines.Find(id);
            var productLineSession = new ProductLineModel();
            productLineSession.ProductLineID = productLine.ProductLineID;

            Session.Add(CC.PRODUCT_SESSION, productLineSession);
            Session["PRODUCT_LINE_SESSION"] = productLineSession.ProductLineID;

            List<ProductImage> productImages = db.ProductImages.Where(line => line.ProductLineID == productLine.ProductLineID).ToList();

            List<PurchaseOrderDetail> purchaseOrderDetails = db.PurchaseOrderDetails.Where(order => order.ProductLineID == productLineSession.ProductLineID).ToList();

            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();

            foreach (var detail in purchaseOrderDetails)
            {
                var order = db.PurchaseOrders.Find(detail.PurchaseOrderID);
                purchaseOrders.Add(order);
            }

            ProductLineDetails productLineDetails = new ProductLineDetails();
            productLineDetails.ProductImages = productImages;
            productLineDetails.ProductLine = productLine;
            productLineDetails.PurchaseOrder = purchaseOrders;

            if (productLine == null)
            {
                return HttpNotFound();
            }
            return View(productLineDetails);
        }

        //Thêm mới hình ảnh
        [HttpPost]
        public ActionResult AddNewImg(PictureUpdate obj)
        {
            string productLineID = Session["PRODUCT_LINE_SESSION"].ToString();
            var file = obj.Picture;
            ProductImage productImage = new ProductImage();
            if (file != null)
            {
                string cnt = (db.ProductLines.Count() + 1).ToString();
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = productLineID + cnt + extension;
                string imgUrl = "/Areas/Administrator/Data/ProductLine" + id_and_extension;

                //productImage.ProductImageID = db.ProductLines.Count() + 1;
                productImage.ProductLineID = productLineID;
                productImage.ImageLink = imgUrl;

                db.ProductImages.Add(productImage);
                db.SaveChanges();

                var path = Server.MapPath("/Areas/Administrator/Data/ProductLine");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if ((System.IO.File.Exists(path + id_and_extension)))
                {
                    System.IO.File.Delete(path + id_and_extension);
                }
                file.SaveAs((path + id_and_extension));
            }
            return RedirectToAction("DetailsProductLine", new { id = productLineID });
        }

        //Xoá ảnh
        public ActionResult DeleteImg(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return PartialView(productImage);
        }

        [HttpPost]
        public ActionResult DeleteImg(long id)
        {
            string productLineID = Session["PRODUCT_LINE_SESSION"].ToString();
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage != null)
            {
                db.ProductImages.Remove(productImage);
                db.SaveChanges();
                return RedirectToAction("DetailsProductLine", new { id = productLineID });
            }
            return PartialView(productImage);
        }

        public ActionResult EditInforLine(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLine productLine = db.ProductLines.Find(id);
            if (productLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productLine.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productLine.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", productLine.SupplierID);
            return PartialView(productLine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInforLine([Bind(Include = "ProductLineID,ProductID,Alias,Status,Size,MinimumQuantityAvailable,SupplierID,ColorID,QuantityInStock,CreatedBy,CreatedDate")] ProductLine productLine)
        {
            if (ModelState.IsValid)
            {
                string username = Session["Username"].ToString();
                db.Entry(productLine).State = EntityState.Modified;
                string note = "Cập nhật thông tin dòng sản phẩm: " + productLine.ProductLineID;
                dao.SaveProductModification(productLine.ProductID, username, note);
                db.SaveChanges();
                return RedirectToAction("DetailsProductLine", new { id = productLine.ProductLineID });
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productLine.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productLine.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", productLine.SupplierID);
            return PartialView(productLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}