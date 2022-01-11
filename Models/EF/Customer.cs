using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Customer
    {
        [Display(Name = "Mã khách hàng")]
        public string CustomerID { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string Name { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Display(Name = "Ngày tạo ")]
        public DateTime? CreateDated { get; set; }

        [Display(Name = "Trạng thái ")]
        public bool Status { get; set; }

        [Display(Name = "Ngày chỉnh sửa ")]
        public DateTime? ModifiledDate { get; set; }

        [Display(Name = "Mã loại khách hàng ")]
        public int CustomerCatergoryID { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
