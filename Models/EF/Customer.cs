using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDated { get; set; }
        public bool Status { get; set; }
        public DateTime? ModifiledDate { get; set; }
        public int CustomerCatergoryID { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
