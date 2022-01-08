using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Common;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class ProductCategoriesController : BaseController
    {
        [HasCredentialAtrribute(RoleID = "VIEW_PRODUCTCATEGORY")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<ProductCategory> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.ProductCategories.ToList<ProductCategory>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ProductCategory emp = new ProductCategory();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.ProductCategories.Where(x => x.ProductCategoryID == id).FirstOrDefault<ProductCategory>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductCategory emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.ProductCategoryID == 0)
                    {

                        db.ProductCategories.Add(emp);
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
                    ProductCategory emp = db.ProductCategories.Where(x => x.ProductCategoryID == id).FirstOrDefault<ProductCategory>();
                    db.ProductCategories.Remove(emp);
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