using ClothesBYW.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class PromotionProductsController : Controller
    {
        // GET: Administrator/PromotionProducts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<Promotion> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.Promotions.ToList<Promotion>();
            }

        }

        public ActionResult AddOrEdit(long id = 0)
        {
            Promotion emp = new Promotion();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.Promotions.Where(x => x.PromotionID == id).FirstOrDefault<Promotion>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Promotion emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.PromotionID == 0)
                    {

                        db.Promotions.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    Promotion emp = db.Promotions.Where(x => x.PromotionID == id).FirstOrDefault<Promotion>();
                    db.Promotions.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        IEnumerable<PromotionProduct> ShowProductInPromotion(int id)
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                PromotionProduct emp = db.PromotionProducts.Where(x => x.PromotionID == id).SingleOrDefault<PromotionProduct>();
                return db.PromotionProducts.ToList<PromotionProduct>();
            }
        }

        [ChildActionOnly]
        public PartialViewResult ListProductsInPromotion(long id)
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                var list = db.PromotionProducts.Include(p => p.Product).Include(p => p.Promotion).Where(products => products.PromotionID == id).ToList();
                return PartialView(list);
            }
        }
    }
}