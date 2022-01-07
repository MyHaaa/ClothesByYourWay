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
using Models.ViewModels;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class UserGroupsController : BaseController
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        // GET: Administrator/UserGroups
        [HasCredentialAtrribute(RoleID = "VIEW_USERGROUP")]
        public ActionResult Index()
        {
            return View(db.UserGroups.ToList());
        }

        public ActionResult GetUserGroupID(string groupID)
        {
            var groupSession = new GroupIDModel();
            groupSession.GroupID = groupID;

            Session.Add(CC.GROUP_SESSION, groupSession);
            Session["GROUP_SESSION"] = groupSession.GroupID;
            return RedirectToAction("UserWithGroup", "UserGroups");

        }
        public ActionResult GetUserGrouppID(string groupID)
        {
            var groupSession = new GroupIDModel();
            groupSession.GroupID = groupID;

            Session.Add(CC.GROUP_SESSION, groupSession);
            Session["GROUP_SESSION"] = groupSession.GroupID;
            return RedirectToAction("RoleWithGroup", "UserGroups");
        }
        public ActionResult UserWithGroup(UserWithGroupView userGroup)
        {
            var groupID = Session[CC.GROUP_SESSION];
            userGroup.UserGroupID = groupID.ToString();
            UserGroup group = db.UserGroups.Find(userGroup.UserGroupID);
            var model = (from a in db.UserGroups
                         join b in db.Employees on a.UserGroupID equals b.UserGroupID
                         where a.UserGroupID == userGroup.UserGroupID
                         select new
                         {
                             EmployeeID = b.EmployeeID,
                             Name = b.Name,
                             UserGroupID = b.UserGroupID
                         }).AsEnumerable().Select(x => new UserWithGroupView()
                         {
                             EmployeeID = x.EmployeeID,
                             Name = x.Name,
                             UserGroupID = x.UserGroupID
                         });


            return View(model.ToList());
        }

        public ActionResult Back()
        {
            Session[CC.GROUP_SESSION] = null;
            return RedirectToAction("Index", "UserGroups");
        }

        [HttpGet]
        public ActionResult RoleWithGroup(RoleWithGroupModel roleGroup)
        {
            var groupID = Session[CC.GROUP_SESSION];
            roleGroup.UserGroupID = groupID.ToString();
            UserGroup group = db.UserGroups.Find(roleGroup.UserGroupID);
            var model = (from a in db.Credentials
                         join b in db.UserGroups on a.UserGroupID equals b.UserGroupID
                         join c in db.Roles on a.RoleID equals c.RoleID
                         where b.UserGroupID == roleGroup.UserGroupID
                         select new
                         {
                             Name = c.Name,
                             RoleID = a.RoleID,
                             UserGroupID = a.UserGroupID
                         }).AsEnumerable().Select(x => new RoleWithGroupModel()
                         {
                             ID = x.RoleID,
                             Name = x.Name,
                             UserGroupID = x.UserGroupID
                         });
            return View(model.ToList());
        }

        //public ActionResult Delete(string id)
        //{

        //    var user = db.Employees.Find(id);
        //    user.UserGroupID = "Employee";
        //    db.SaveChanges();
        //    return RedirectToAction("UserWithGroup");
        //    //return View();
        //}

        // POST: Admin/User/Delete/5


        //public ActionResult AddNewUser(UserWithGroupView userGroup)
        //{
        //    var groupID = Session[CC.GROUP_SESSION];
        //    userGroup.UserGroupID = groupID.ToString();
        //    var model = (from a in db.UserGroups
        //                 join b in db.Employees on a.UserGroupID equals b.UserGroupID
        //                 where a.UserGroupID != groupID
        //                 select new
        //                 {
        //                     EmployeeID = b.EmployeeID,
        //                     Name = b.Name,
        //                     GroupID = b.UserGroupID
        //                 }).AsEnumerable().Select(x => new UserWithGroupView()
        //                 {
        //                     EmployeeID = x.EmployeeID,
        //                     Name = x.Name,
        //                     GroupID = x.GroupID
        //                 });
        //    return View(model);
        //}

        public ActionResult AddNewRole(RoleWithGroupModel userRole)
        {
            var groupID = Session[CC.GROUP_SESSION];
            userRole.UserGroupID = groupID.ToString();
            //var model = (from a in db.Credentials
            //             join c in db.Rolees on a.RoleID equals c.ID
            //            where (a.UserGroupID != userRole.UserGroupID)
            //            select new
            //            {
            //                Name = c.Name,
            //                RoleID = c.ID,
            //            }).AsEnumerable().Select(x => new RoleWithGroupModel()
            //            {
            //                ID = x.RoleID,
            //                Name = x.Name,
            //            });
            var roleOfUserGroup = (from a in db.Credentials
                                   join b in db.UserGroups on a.UserGroupID equals b.UserGroupID
                                   join c in db.Roles on a.RoleID equals c.RoleID
                                   where b.UserGroupID == userRole.UserGroupID
                                   select new
                                   {
                                       RoleID = a.RoleID,
                                       RoleName = c.Name
                                   });
            var model = (from a in db.Roles
                         where !roleOfUserGroup.Select(x => x.RoleID).Contains(a.RoleID)
                         select a).AsEnumerable().Select(x => new RoleWithGroupModel()
                         {
                             ID = x.RoleID,
                             Name = x.Name,
                         });
            return View(model);
        }

        public ActionResult Add(string id)
        {
            var groupID = Session[CC.GROUP_SESSION];
            var user = db.Employees.Find(id);
            user.UserGroupID = groupID.ToString();
            db.SaveChanges();
            return RedirectToAction("AddNewUser");
        }
        public ActionResult AddRole(string id)
        {
            var groupID = Session[CC.GROUP_SESSION];
            Credential credential = new Credential();
            credential.UserGroupID = groupID.ToString();
            credential.RoleID = id;
            db.Credentials.Add(credential);
            db.SaveChanges();
            return RedirectToAction("AddNewRole");
        }

        public ActionResult DeleteRole(string id)
        {
            var groupID = Session[CC.GROUP_SESSION];
            string us = groupID.ToString();
            var credential = db.Credentials.Where(x => (x.UserGroupID == us && x.RoleID == id)).SingleOrDefault();

            db.Credentials.Remove(credential);
            db.SaveChanges();


            return RedirectToAction("RoleWithGroup");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

