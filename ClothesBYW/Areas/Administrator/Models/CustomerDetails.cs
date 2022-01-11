using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class CustomerDetails
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}