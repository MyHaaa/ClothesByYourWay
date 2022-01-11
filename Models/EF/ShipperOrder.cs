using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class ShipperOrder
    {
        [Display(Name = "Mã vận đơn ")]
        public int ShipperOrderID { get; set; }
        [Display(Name = "Mã đơn hàng ")]
        public string OrderID { get; set; }
        [Display(Name = "Mã nhân viên ")]
        public string EmployeeID { get; set; }
        [Display(Name = "Mã shipper ")]
        public string ShipperID { get; set; }
        [Display(Name = "Ngày giao hàng dự kiến ")]
        public DateTime? DeliveryDatetime { get; set; }
        [Display(Name = "Ghi chú giao hàng ")]
        public string DeliveryNote { get; set; }
        public virtual Order Order { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
