using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Supplier
    {
        [Display(Name = "Mã nhà cung cấp ")]
        public int SupplierID { get; set; }
        [Display(Name = "Tên nhà cung cấp ")]
        public string Name { get; set; }
        [Display(Name = "Email ")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại người đại diện ")]
        public string ContactPerson { get; set; }
        [Display(Name = "Số điệ thoại nhà cung cấp ")]
        public string PhoneSupplier { get; set; }
        [Display(Name = "Số điện thoại người đại diện ")]
        public string PhoneContactPerson { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
    }
}
