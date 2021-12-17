using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public static class ModalSeedData
    {
        public static void Seed(ClothesBYWDbContext context)
        {
            context.Colors.Add(new Color()
            {
                ColorName = "Red",
                Texture = "xxx"
            });
            context.SaveChanges();
        }
    }
}
