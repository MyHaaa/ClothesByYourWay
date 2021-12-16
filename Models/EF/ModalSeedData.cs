﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class ModalSeedData: DropCreateDatabaseAlways<ClothesBYWDbContext>
    {
        protected override void Seed(ClothesBYWDbContext context)
        {
            context.Colors.Add(new Color()
            {
                ColorName = "Test",
                Texture = "xxx"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}