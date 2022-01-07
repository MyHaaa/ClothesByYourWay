using ClothesBYW.Base;
using ClothesBYW.Repos.Interface;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Repos.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public int Count()
        {
            return table.Count();
        }


    }
}
