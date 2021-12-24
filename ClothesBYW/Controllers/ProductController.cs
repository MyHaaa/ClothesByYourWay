using ClothesBYW.Models.Customer;
using Models.Dao.Customer;
using Models.EF;
using Models.ViewModels.Customer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(ProductListRequest request)
        {
            var dao = new ProductDao();
            if (request.CategoryID != null) return View(dao.GetProducts(int.Parse(request.CategoryID.ToString())));
            if (!String.IsNullOrEmpty(request.Keyword)) return View(dao.GetProducts(request.Keyword));
            if (request.SortBy != null)
            {
                switch (request.SortBy)
                {
                    case 1: return View(dao.GetProductsSortByNew());
                    case 2: return View(dao.GetProductsSortByMostSale());
                    default: return View(dao.GetProducts());
                }
            }

            if (request.PriceRange != null)
            {
                return View(dao.GetProducts(double.Parse(request.PriceRange.ToString())));
            }
            return View(dao.GetProducts());
        }
        public PartialViewResult ProductCategoriesPartial()
        {
            var dao = new ProductDao();
            return PartialView(dao.GetCategories());
        }
        public ActionResult Detail(string id)
        {
            var dao = new ProductDao();
            return View(dao.GetProductDetail(id));
        }
        public ActionResult SelectProductLine(string currentLine, string value, bool isSize)
        {
            var dao = new ProductDao();
            var lineID = dao.GetProductLineIDWhenChangeValue(currentLine, value, isSize);
            return RedirectToAction("Detail", "Product", new { id = lineID });
        }
        [HttpPost]
        public ActionResult SearchByKeyword(string keyword)
        {
            return RedirectToAction("Index", "Product", new ProductListRequest()
            {
                CategoryID = null,
                Keyword = keyword
            });
        }
        public ActionResult ProductFeedbacksPartial()
        {
            var dao = new FeedbackDao();
            return PartialView(dao.GetFeedbacks());
        }
        [HttpPost]
        public ActionResult UploadFeedback(string productID, int star, string title, string content)
        {
            var dao = new FeedbackDao();
            dao.UploadFeedback(UserLoginSingleton.GetInstance().GetAccount().ID, productID, star, title, content);
            return RedirectToAction("Detail", "Product", new { id = productID });
        }
    }
}