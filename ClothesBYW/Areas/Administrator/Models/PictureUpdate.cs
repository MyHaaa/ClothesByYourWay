using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class PictureUpdate
    {
        [Required]
        public HttpPostedFileWrapper Picture { get; set; }
    }
}