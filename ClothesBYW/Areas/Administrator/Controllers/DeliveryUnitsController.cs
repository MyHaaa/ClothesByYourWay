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
    public class DeliveryUnitsController : Controller
    {
        // GET: Administrator/DeliveryUnits
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<DeliveryUni> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.DeliveryUnis.ToList<DeliveryUni>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            DeliveryUni emp = new DeliveryUni();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.DeliveryUnis.Where(x => x.DeliveryUnitID == id).FirstOrDefault<DeliveryUni>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(DeliveryUni emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.DeliveryUnitID == 0)
                    {
                        db.DeliveryUnis.Add(emp);
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
                    DeliveryUni emp = db.DeliveryUnis.Where(x => x.DeliveryUnitID == id).FirstOrDefault<DeliveryUni>();
                    db.DeliveryUnis.Remove(emp);
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