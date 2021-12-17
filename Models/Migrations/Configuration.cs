namespace Models.Migrations
{
    using Models.EF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.EF.ClothesBYWDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClothesBYWDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            AddBrands(context);
            base.Seed(context);
        }
        private void AddBrands(ClothesBYWDbContext context)
        {
            var item1 = new Brand()
            {
                BrandID = 1,
                BrandName = "Quintiles",
                ImageBrand = "/Assets/Client/img/brand-1.png"
            };
            var item2 = new Brand()
            {
                BrandID = 2,
                BrandName = "IndiaCapital",
                ImageBrand = "/Assets/Client/img/brand-2.png"
            };
            var item3 = new Brand()
            {
                BrandID = 3,
                BrandName = "PaperlinX",
                ImageBrand = "/Assets/Client/img/brand-3.png"
            };
            var item4 = new Brand()
            {
                BrandID = 4,
                BrandName = "InfraRed",
                ImageBrand = "/Assets/Client/img/brand-4.png"
            };
            var item5 = new Brand()
            {
                BrandID = 5,
                BrandName = "Erlang",
                ImageBrand = "/Assets/Client/img/brand-5.png"
            };
            var item6 = new Brand()
            {
                BrandID = 6,
                BrandName = "Sport England",
                ImageBrand = "/Assets/Client/img/brand-6.png"
            };
            context.Brands.Add(item1);
            context.Brands.Add(item2);
            context.Brands.Add(item3);
            context.Brands.Add(item4);
            context.Brands.Add(item5);
            context.Brands.Add(item6);
        }

    }
}
