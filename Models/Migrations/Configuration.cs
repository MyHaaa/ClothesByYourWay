namespace Models.Migrations
{
    using Models.EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.EF.ClothesBYWDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.EF.ClothesBYWDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Colors.Add(new Color()
            {
                ColorName = "Red",
                Texture = "xxx"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
