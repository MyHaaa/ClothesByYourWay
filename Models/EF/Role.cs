using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Role
    {
        public string RoleID { get; set; }
        public string Name { get; set; }
        public virtual List<Credential> Credentials { get; set; }
    }
}
