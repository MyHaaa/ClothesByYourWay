using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Color
    {
        [Display(Name = "Mã màu")]
        public int ColorID { get; set; }
        [Display(Name = "Tên màu")]
        public string ColorName { get; set; }
        [Display(Name = "Bảng màu")]
        public string Texture { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
    }
}
