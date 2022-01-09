using ClothesBYW.Commands;
using ClothesBYW.Common;
using Models.Dao;
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
        private CommandManager commandManager = null;
        private SupplierDao dao = new SupplierDao();

        // GET: Administrator/Colors
        public SuppliersController()
        {
            this.commandManager = new CommandManager();
        }

        public SuppliersController(CommandManager commandManager)
        {
            this.commandManager = commandManager;
        }
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
                        commandManager.IVoke(new AddSupplierCommand(emp, dao));

                    }
                    else
                    {
                        //commandManager.IVoke(new EditSupplierCommand(emp, dao));
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
                    commandManager.IVoke(new DeleteSupplierCommand(id, dao));
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