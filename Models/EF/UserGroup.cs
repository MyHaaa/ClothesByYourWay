using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class UserGroup
    {
        public string UserGroupID { get; set; }
        public string Name { get; set; }
        public virtual List<Credential> Credentials { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
