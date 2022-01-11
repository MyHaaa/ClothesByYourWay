using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Role
    {
        [Display(Name = "Mã quyền truy cập ")]
        public string RoleID { get; set; }
        [Display(Name = "Tên quyền truy cập ")]
        public string Name { get; set; }
        public virtual List<Credential> Credentials { get; set; }
    }
}
