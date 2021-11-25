using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}