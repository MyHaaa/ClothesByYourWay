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
    public class ColorsController : Controller
    {
        private CommandManager commandManager = null;
        private ColorDao dao = new ColorDao();

        // GET: Administrator/Colors
        public ColorsController()
        {
            this.commandManager = new CommandManager();
        }

        public ColorsController(CommandManager commandManager )
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

        IEnumerable<Color> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.Colors.ToList<Color>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Color emp = new Color();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.Colors.Where(x => x.ColorID == id).FirstOrDefault<Color>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Color emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.ColorID == 0)
                    {
                        commandManager.IVoke(new AddColorCommand(emp, dao));
                    }
                    else
                    {
                        commandManager.IVoke(new EditColorCommand(emp, dao));
                        //db.Entry(emp).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Undo()
        {
            commandManager.Undo();

            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    commandManager.IVoke(new DeleteColorCommand(id, dao));
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