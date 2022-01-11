using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class UserGroup
    {
        [Display(Name = "Mã nhóm người dùng ")]
        public string UserGroupID { get; set; }
        [Display(Name = "Tên nhóm người dùng ")]
        public string Name { get; set; }
        public virtual List<Credential> Credentials { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
