using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class AddSupplierCommand : ICommand
    {
        private readonly Supplier supplier;
        private SupplierDao dao;

        public AddSupplierCommand(Supplier Supplier, SupplierDao dao)
        {
            this.supplier = Supplier;
            this.dao = dao;
        }


        public bool CanExcute()
        {
            var s = dao.GetByName(supplier.Name);
            return ( s == null);
        }

        public void Execute()
        {
            dao.Insert(supplier);
        }

        public void Undo()
        {
            dao.Delete(supplier.SupplierID);
        }
    }
}