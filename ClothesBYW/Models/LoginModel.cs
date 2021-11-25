using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesBYW.Models
{
    public class LoginModel
    {
        [Key]   
        [Required(ErrorMessage = "Vui lòng nhập Email bạn đã đăng ký")]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập mât khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}