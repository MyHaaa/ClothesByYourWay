using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneSupplier { get; set; }
        public string PhoneContactPerson { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
    }
}
