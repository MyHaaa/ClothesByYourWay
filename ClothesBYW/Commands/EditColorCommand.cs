using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Commands
{
    public class EditColorCommand : ICommand
    {
        private readonly Color Color;
        private ColorDao dao;

        public EditColorCommand(Color Color, ColorDao dao)
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
            dao.Update(Color);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}