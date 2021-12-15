using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Customer.Product
{
    public class ProductListRequest
    {
        public int? CategoryID { get; set; }
        public string Keyword { get; set; }
        public int? SortBy { get; set; }
        public double? PriceRange { get; set; }
        public ProductListRequest() { }
        public ProductListRequest(int cateID)
        {
            this.CategoryID = cateID;
        }
    }
}
