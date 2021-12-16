using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class CustomerCategory
    {
        public int CustomerCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}
