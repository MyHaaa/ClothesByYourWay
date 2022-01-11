using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Employee
    {
        [Display(Name = "Mã nhân viên")]
        public string EmployeeID { get; set; }

        [Display(Name = "Tên nhân viên ")]
        public string Name { get; set; }

        [Display(Name = "Tên đăng nhập ")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu ")]
        public string Password { get; set; }

        [Display(Name = "Ngày sinh ")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "CCCD/CMND ")]
        public string CitizenID { get; set; }

        [Display(Name = "Mã nhóm người dùng ")]
        public string UserGroupID { get; set; }

        [Display(Name = "Số điện thoại ")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }

        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Display(Name = "Ảnh đại diện ")]
        public string Image { get; set; }
        public DateTime? CreateDated { get; set; }
        public bool Status { get; set; }
        public Guid? ActivationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public string ResetPasswordCode { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
