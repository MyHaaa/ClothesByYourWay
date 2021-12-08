using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public partial class PromotionProduct
    {

        public long PromotionProductID { get; set; }

        public long PromotionID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        public decimal? EachPrice { get; set; }

        public virtual Product Product { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
