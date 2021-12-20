using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Customer.Product
{
    public class ProductDetailModel
    {
        public string ProductLineID { get; set; }
        public string ProductID { get; set; }
        public string Size { get; set; }
        public int ColorID { get; set; }
        public long QuantityInStock { get; set; }
        public string Name { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? StandardPrice { get; set; }
        public List<string> Sizes { get; set; }
        public List<Color> Colors { get; set; }
        public virtual List<Tuple<int, string>> ListIDColor_Line { get; set; }
        public int FeedbackCount { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
