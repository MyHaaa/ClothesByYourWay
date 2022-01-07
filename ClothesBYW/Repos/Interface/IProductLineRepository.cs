using ClothesBYW.Base;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesBYW.Repos.Interface
{
    public interface IProductLineRepository : IRepository<ProductLine>
    {
        IEnumerable<ProductLine> GetProductLinesWithSupplier(int? id);
    }
}
