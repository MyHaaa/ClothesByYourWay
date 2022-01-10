using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class EditCustomerCategoryCommand : ICommand
    {
        private readonly CustomerCategory CustomerCategory;
        private CustomerCategoryDao dao;

        public EditCustomerCategoryCommand(CustomerCategory CustomerCategory, CustomerCategoryDao dao)
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
            dao.Update(CustomerCategory);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        } 
    }
}