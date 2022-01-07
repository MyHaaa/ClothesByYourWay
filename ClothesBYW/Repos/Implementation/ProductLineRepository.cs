using ClothesBYW.Base;
using ClothesBYW.Repos.Interface;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Repos.Implementation
{
    public class ProductLineRepository : Repository<ProductLine>, IProductLineRepository
    {
        public IEnumerable<ProductLine> GetProductLinesWithSupplier(int? id)
        {
            return table.Where(x => x.SupplierID == id).ToList();
        }
    }
}