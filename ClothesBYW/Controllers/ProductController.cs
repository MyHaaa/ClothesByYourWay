using Models.Dao.Customer;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int? cateID)
        {
            var dao = new ProductDao();
            try
            {
                return View(dao.GetProducts(int.Parse(cateID.ToString())));
            }
            catch (Exception)
            {
                return View(dao.GetProducts());
            }
        }
        public ActionResult ProductCategoriesPartial()
        {
            var dao = new ProductDao();
            return View(dao.GetCategories());
        }
        public ActionResult Detail(string id)
        {
            var dao = new ProductDao();
            return View(dao.GetProductDetail(id));
        }
    }
}