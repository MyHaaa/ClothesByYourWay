using ClothesBYW.Base;
using ClothesBYW.Repos.Interface;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ClothesBYW.Repos.Implementation
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public int Count()
        {
            return table.Count();
        }

        public IEnumerable<PurchaseOrder> GetAllOrder()
        {
            return table.ToList();
        }
        public void ChangeStatus(string id, int statusID)
        {
            var po = table.Find(id);
            po.Status = statusID;
        }

        public void ModifiedInfor(string id, string username, DateTime dateTime)
        {
            var po = table.Find(id);
            po.ModifiledBy = username;
            po.ModifiledDate = dateTime;
        }

        public PurchaseOrder FindPOSupplier(int id)
        {
            return (PurchaseOrder)table.Where(p => p.SupplierID == id);
        }
    }
}
