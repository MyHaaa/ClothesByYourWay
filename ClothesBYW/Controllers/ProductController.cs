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
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}