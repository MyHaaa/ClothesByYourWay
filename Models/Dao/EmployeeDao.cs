using Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class EmployeeDao
    {
        private ClothesBYWDbContext db = null;

        public EmployeeDao()
        {
            db = new ClothesBYWDbContext();
        }
        public string Insert(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.EmployeeID;
        }

        public object GetById(string userName)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<User> ListAll(string searchString, int page, int pageSize)
        //{
        //    IQueryable<User> model = db.Users;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString));
        //    }
        //    return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        //}

        public bool Update(Employee entity)
        {
            try
            {
                var user = db.Employees.Find(entity.EmployeeID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.DateOfBirth = entity.DateOfBirth;
                user.CitizenID = entity.CitizenID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee ViewDetail(string userID)
        {
            return db.Employees.Find(userID); //đây là phương thức tìm kiếm bằng khóa chính
        }

        public Employee GetByID(string userName)
        {
            return db.Employees.SingleOrDefault(x => x.Username == userName);
        }
        public int Login(string username, string password)
        {
            var result = db.Employees.SingleOrDefault(x => x.Username == username); // Count bằng LinQ
            if (result == null) // Nếu kết quả trả về là null, tức là không có tài khoản này tồn tại
            {
                return 0;
            }
            else
            {
                if (result.Status == false) // Status bằng false, tức là tài khoản này ko đc active => bị khóa
                    return -1;
                else
                {
                    if (result.Password == password) // mật khẩu hợp lệ
                        return 1;
                    else //Ngược lại, mật khẩu không hợp lệ
                        return -2;
                }
            }
        }

        public IEnumerable<Employee> ListUserWithRole(string userGroup)
        {
            var userList = db.Employees.Where(x => x.UserGroupID == userGroup).ToList();
            return userList;
        }

        public List<string> GetListCredential(string userName)
        {
            var user = db.Employees.Single(x => x.Username == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.UserGroupID
                        join c in db.Roles on a.RoleID equals c.RoleID
                        where b.UserGroupID == user.UserGroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(string username, string password, bool IsLoginAdmin = false)
        {
            var result = db.Employees.SingleOrDefault(x => x.Username == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (IsLoginAdmin == true)
                {
                    if (result.UserGroupID == CommonConstant.ADMIN || result.UserGroupID == CommonConstant.MANAGER || result.UserGroupID == CommonConstant.SALER || result.UserGroupID == CommonConstant.CUSTOMER_CARE_STAFF || result.UserGroupID == CommonConstant.WAREHOUSE_STAFF)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.Employees.Find(id);
                db.Employees.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Count()
        {
            var users = db.Employees.Count();
            return users;
        }

        public bool ChangeStatus(string id)
        {
            var employee = db.Employees.Find(id);
            employee.Status = !employee.Status;
            db.SaveChanges();
            return employee.Status;
        }
    }
}
