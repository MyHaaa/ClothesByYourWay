using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClothesBYW.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Vui lòng nhập UserName")]
        public string Username { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Fullname { set; get; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có độ dài ít nhất là 8")]
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string Password { set; get; }

        [Display(Name = " Password nhập lại")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password nhập lại không khớp")]
        public string ConfirmPassword { set; get; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Vui lòng nhập địa chỉ thường trú")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Required email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Required phone")]
        [Display(Name = "Phone")]
        public string Phone { set; get; }
    }
}