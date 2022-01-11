using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Shipper
    {
        [Display(Name = "Mã shipper ")]
        public string ShipperID { get; set; }
        [Display(Name = "Tên shipper ")]
        public string Name { get; set; }
        [Display(Name = "Email ")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại ")]
        public string Phone { get; set; }
        [Display(Name = "Mã đơn vị giao hàng ")]
        public int DeliveryUnitID { get; set; }
        public virtual DeliveryUni DeliveryUni { get; set; }
        public virtual List<ShipperOrder> ShipperOrders { get; set; }
    }
}
