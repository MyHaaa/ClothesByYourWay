using ClothesBYW.Base;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesBYW.Repos.Interface
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        IEnumerable<PurchaseOrder> GetAllOrder();

        int Count();

        void ChangeStatus(string id, int statusID);

        void ModifiedInfor(string id, string username, DateTime dateTime);

        PurchaseOrder FindPOSupplier(int id);

    }
}
