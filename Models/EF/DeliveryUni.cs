using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class DeliveryUni
    {
        [Display(Name = "Mã đơn vị giao hàng ")]
        public int DeliveryUnitID { get; set; }

        [Display(Name = "Tên đơn vị ")]
        public string Name { get; set; }

        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }

        [Display(Name = "Người đại diện ")]
        public string ContactPerson { get; set; }

        [Display(Name = "Số điện thoại người đại diện ")]
        public string PhoneContactPerson { get; set; }

        [Display(Name = "Email người đại diện ")]
        public string EmailContactPerson { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
    }
}
