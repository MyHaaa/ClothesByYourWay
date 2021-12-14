using Models.EF;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class UserGroupDao
    {
        private ClothesBYWDbContext db = null;

        public UserGroupDao()
        {
            db = new ClothesBYWDbContext();
        }


        public bool Delete(string roleID)
        {
            try
            {
                var credenital = db.Credentials.SingleOrDefault(x => x.RoleID == roleID);
                db.Credentials.Remove(credenital);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<UserWithGroupView> ListUser(string groupID)
        {
            UserGroup group = db.UserGroups.Find(groupID);
            var model = (from a in db.UserGroups
                         join b in db.Employees on a.UserGroupID equals b.UserGroupID
                         where a.UserGroupID == groupID
                         select new
                         {
                             EmployeeID = b.EmployeeID,
                             Name = b.Name,
                             GroupID = b.UserGroupID
                         }).AsEnumerable().Select(x => new UserWithGroupView()
                         {
                             EmployeeID = x.EmployeeID,
                             Name = x.Name,
                             GroupID = x.GroupID
                         });
            return model.ToList();
        }
        public List<Credential> ListRole(string groupID)
        {
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.UserGroupID
                        join c in db.Roles on a.RoleID equals c.RoleID
                        where b.UserGroupID == groupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {

                            UserGroupID = x.UserGroupID,
                            RoleID = x.RoleID
                        });
            return data.ToList();
        }
    }
}
