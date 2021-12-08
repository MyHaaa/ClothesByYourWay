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
    public class SuppliersController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<Supplier> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.Suppliers.ToList<Supplier>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Supplier emp = new Supplier();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault<Supplier>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Supplier emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.SupplierID == 0)
                    {

                        db.Suppliers.Add(emp);
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
                    Supplier emp = db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault<Supplier>();
                    db.Suppliers.Remove(emp);
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