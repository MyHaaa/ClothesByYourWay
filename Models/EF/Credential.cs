using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Credential
    {
        public int CredentialID { get; set; }
        public string UserGroupID { get; set; }
        public string RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
