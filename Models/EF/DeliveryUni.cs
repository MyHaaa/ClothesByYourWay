using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class DeliveryUni
    {
        public int DeliveryUnitID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneContactPerson { get; set; }
        public string EmailContactPerson { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
    }
}
