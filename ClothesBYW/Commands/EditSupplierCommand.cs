using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class EditSupplierCommand : ICommand
    {
        private readonly Supplier supplier;
        private SupplierDao dao;

        public EditSupplierCommand(Supplier supplier, SupplierDao dao)
        {
            this.supplier = supplier;
            this.dao = dao;
        }

        public bool CanExcute()
        {
            return (dao.GetByName(supplier.Name) == null);
        }

        public void Execute()
        {
            dao.Update(supplier);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}