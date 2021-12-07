using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Models.Customer
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