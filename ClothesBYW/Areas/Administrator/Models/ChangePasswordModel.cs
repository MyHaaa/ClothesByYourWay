using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ClothesBYW.Areas.Administrator.Models
{
    public class ChangePasswordModel
    {
        [Key]
        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu cũ!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu mới!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Nhập lại mật khẩu mới")]
        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu mới!")]
        [Compare(otherProperty: "NewPassword", ErrorMessage = "Mật khẩu nhập lại không trùng khớp!")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

    }
}
}