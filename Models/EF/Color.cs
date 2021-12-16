using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Color
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string Texture { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
    }
}
