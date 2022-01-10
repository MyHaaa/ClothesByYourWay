using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Commands
{
    public class AddCustomerCategoryCommand : ICommand
    {
        private readonly CustomerCategory CustomerCategory;
        private CustomerCategoryDao dao;


        public AddCustomerCategoryCommand(CustomerCategory CustomerCategory, CustomerCategoryDao dao)
        {
            this.CustomerCategory = CustomerCategory;
            this.dao = dao;
        }

        public bool CanExcute()
        {
            return (dao.GetByName(CustomerCategory.Name) == null);
        }

        public void Execute()
        {
            dao.Insert(CustomerCategory);
        }

        public void Undo()
        {
            dao.Delete(CustomerCategory.CustomerCategoryID);
        }
    }
}