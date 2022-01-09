using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class DeleteSupplierCommand : ICommand
    {
        private readonly int id;
        private SupplierDao dao;


        public DeleteSupplierCommand(int id, SupplierDao dao)
        {
            this.id = id;
            this.dao = dao;
        }
        public bool CanExcute()
        {
            return (dao.ProductCount(id) == 0);
        }

        public void Execute()
        {
            dao.Delete(id);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}