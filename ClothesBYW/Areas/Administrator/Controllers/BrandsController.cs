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
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<Brand> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.Brands.ToList<Brand>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Brand emp = new Brand();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.Brands.Where(x => x.BrandID == id).FirstOrDefault<Brand>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Brand emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.BrandID == 0)
                    {
                        emp.BrandID = db.Brands.Count() + 1;

                        db.Brands.Add(emp);
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
                    Brand emp = db.Brands.Where(x => x.BrandID == id).FirstOrDefault<Brand>();
                    db.Brands.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}