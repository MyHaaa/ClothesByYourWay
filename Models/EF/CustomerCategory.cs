using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class CustomerCategory
    {
        [Display(Name = "Mã loại khách hàng ")]
        public int CustomerCategoryID { get; set; }

        [Display(Name = "Tên khách hàng ")]
        public string Name { get; set; }

        [Display(Name = "Mô tả ")]
        public string Description { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}
