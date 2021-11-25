using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Common
{
    [Serializable]
    public class UserLogin
    {
        public string EmployeeID { get; set; }
        public string Username { get; set; }
        public string UserGroupID { get; set; }
    }
}