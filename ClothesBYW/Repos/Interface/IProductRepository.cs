using ClothesBYW.Base;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesBYW.Repos.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        int Count();


    }
}
