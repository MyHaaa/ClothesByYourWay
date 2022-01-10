using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class DeleteCustomerCategoryCommand : ICommand
    {

        private readonly int id;
        private CustomerCategoryDao dao;


        public DeleteCustomerCategoryCommand(int id, CustomerCategoryDao dao)
        {
            this.id = id;
            this.dao = dao;
        }

        public bool CanExcute()
        {
            var cate = dao.GetByID(id);
            return (dao.NameCount(cate.Name) == null);
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