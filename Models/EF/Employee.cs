using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CitizenID { get; set; }
        public string UserGroupID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDated { get; set; }
        public bool Status { get; set; }
        public Guid? ActivationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public string ResetPasswordCode { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
