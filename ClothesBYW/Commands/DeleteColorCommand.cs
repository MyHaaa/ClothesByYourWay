using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class DeleteColorCommand : ICommand
    {
        private readonly int id;
        private ColorDao dao;


        public DeleteColorCommand(int id, ColorDao dao)
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