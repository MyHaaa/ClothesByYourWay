using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Models.Customer
{
    public class ProfieModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime? DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
        public string CurrentOrder { get; set; } = "";
    }
}