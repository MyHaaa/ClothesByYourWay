using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Commands
{
    public class AddColorCommand : ICommand
    {
        private readonly Color Color;
        private ColorDao dao;


        public AddColorCommand(Color Color, ColorDao dao)
        {
            this.Color = Color;
            this.dao = dao;
        }

        public bool CanExcute()
        {
            return (dao.GetByName(Color.ColorName) == null);
        }

        public void Execute()
        {
            dao.Insert(Color);
        }

        public void Undo()
        {
            dao.Delete(Color.ColorID);
        }
    }
}