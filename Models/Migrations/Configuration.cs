using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Models.EF;

namespace Models.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ClothesBYWDbContext>
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
            AddColors(context);
            AddCustomerCategories(context);
            AddCustomers(context);
            AddDeliveryUnits(context);
            AddProductCategories(context);
            AddProducts(context);
            AddSupplier(context);
            AddProductLines(context);
            AddPrices(context);
            AddVoucher(context);
            AddUserGroup(context);
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
        private void AddColors(ClothesBYWDbContext context)
        {
            string baseImageUrl = "/Assets/Client/img/Product";

            var item1 = new Color()
            {
                ColorID = 1,
                ColorName = "Navy Blue",
                Texture = baseImageUrl + "/texture/navy-blue.png",
            };

            var item2 = new Color()
            {
                ColorID = 2,
                ColorName = "Green",
                Texture = baseImageUrl + "/texture/green.png",
            };
            var item3 = new Color()
            {
                ColorID = 3,
                ColorName = "Mustard Yellow Floral Print",
                Texture = baseImageUrl + "/texture/mustard-yellow-floral-print.jpg",
            };
            var item4 = new Color()
            {
                ColorID = 4,
                ColorName = "Red Floral Print",
                Texture = baseImageUrl + "/texture/red-floral-print.png",
            };
            var item5 = new Color()
            {
                ColorID = 5,
                ColorName = "Navy Blue Floral Print",
                Texture = baseImageUrl + "/texture/navy-blue-floral-print.jpg",
            };
            var item6 = new Color()
            {
                ColorID = 6,
                ColorName = "Red",
                Texture = baseImageUrl + "/texture/red.png",
            };
            var item7 = new Color()
            {
                ColorID = 7,
                ColorName = "White",
                Texture = baseImageUrl + "/texture/white.png",
            };
            var item8 = new Color()
            {
                ColorID = 8,
                ColorName = "Royal White",
                Texture = baseImageUrl + "/texture/royal-white.jpg",
            };
            var item9 = new Color()
            {
                ColorID = 9,
                ColorName = "Royal Blue",
                Texture = baseImageUrl + "/texture/royal-blue.jpg",
            };
            var item10 = new Color()
            {
                ColorID = 10,
                ColorName = "Burgundy",
                Texture = baseImageUrl + "/texture/burgundy.png",
            };
            var item11 = new Color()
            {
                ColorID = 11,
                ColorName = "Purple",
                Texture = baseImageUrl + "/texture/purple.jpg",
            };
            var item12 = new Color()
            {
                ColorID = 12,
                ColorName = "Hunter Green",
                Texture = baseImageUrl + "/texture/hunter-green.png",
            };
            context.Colors.Add(item1);
            context.Colors.Add(item2);
            context.Colors.Add(item3);
            context.Colors.Add(item4);
            context.Colors.Add(item5);
            context.Colors.Add(item6);
            context.Colors.Add(item7);
            context.Colors.Add(item8);
            context.Colors.Add(item9);
            context.Colors.Add(item10);
            context.Colors.Add(item11);
            context.Colors.Add(item12);
        }
        private void AddCustomerCategories(ClothesBYWDbContext context)
        {
            var item1 = new CustomerCategory()
            {
                CustomerCategoryID = 1,
                Name = "New Customer",
                Description = "Level 0"
            };
            var item2 = new CustomerCategory()
            {
                CustomerCategoryID = 2,
                Name = "Basic Customer",
                Description = "Level 2"
            };
            var item3 = new CustomerCategory()
            {
                CustomerCategoryID = 3,
                Name = "Potential Customer",
                Description = "Level 3"
            };
            var item4 = new CustomerCategory()
            {
                CustomerCategoryID = 4,
                Name = "VIP Customer",
                Description = "Level 4"
            };
            var item5 = new CustomerCategory()
            {
                CustomerCategoryID = 5,
                Name = "Partner",
                Description = "Level 5"
            };
            context.CustomerCategories.Add(item1);
            context.CustomerCategories.Add(item2);
            context.CustomerCategories.Add(item3);
            context.CustomerCategories.Add(item4);
            context.CustomerCategories.Add(item5);
        }
        private void AddCustomers(ClothesBYWDbContext context)
        {
            var item1 = new Customer()
            {
                CustomerID = Guid.NewGuid().ToString(),
                Name = "Mili Anna",
                Username = "millianna",
                Password = "Abcd1234!",
                DateOfBirth = new DateTime(2000, 10, 25),
                Phone = "03213154854",
                Address = "Standford Chua Lang",
                Email = "milli@teafan.com",
                CreateDated = DateTime.Now,
                Status = true,
                ModifiledDate = DateTime.Now,
                CustomerCatergoryID = 1,
                IsEmailVerified = true,
                ActivationCode = Guid.NewGuid()
            };
            var item2 = new Customer()
            {
                CustomerID = Guid.NewGuid().ToString(),
                Name = "Anna Lee",
                Username = "annalee",
                Password = "Abcd1234!",
                DateOfBirth = new DateTime(2000, 10, 25),
                Phone = "03213154854",
                Address = "Standford Chua Lang",
                Email = "annalee@teafan.com",
                CreateDated = DateTime.Now,
                Status = true,
                ModifiledDate = DateTime.Now,
                CustomerCatergoryID = 2,
                IsEmailVerified = true,
                ActivationCode = Guid.NewGuid()
            };
            context.Customers.Add(item1);
            context.Customers.Add(item2);
        }
        private void AddDeliveryUnits(ClothesBYWDbContext context)
        {
            var item1 = new DeliveryUni()
            {
                DeliveryUnitID = 1,
                Name = "Giao Hang Tiet Kiem",
                Email = "giaohangtietkiem@contact.com",
                Address = "Harvard Dong Da",
                ContactPerson = "Nguyen Le",
                PhoneContactPerson = "132003232",
                EmailContactPerson = "nguyenle@singer.com"
            };
            var item2 = new DeliveryUni()
            {
                DeliveryUnitID = 2,
                Name = "Giao Hang Khong Tiet Kiem",
                Email = "giaohang-ko-tietkiem@contact.com",
                Address = "Harvard Dong Da",
                ContactPerson = "Nguyen Le",
                PhoneContactPerson = "132003232",
                EmailContactPerson = "nguyenle@singer.com"
            };
            context.DeliveryUnis.Add(item1);
            context.DeliveryUnis.Add(item2);
        }
        private void AddProductCategories(ClothesBYWDbContext context)
        {
            var item1 = new ProductCategory()
            {
                ProductCategoryID = 1,
                Name = "Dress",
                MeteKeyword = "dress",
                Status = true
            };
            var item2 = new ProductCategory()
            {
                ProductCategoryID = 2,
                Name = "Top",
                MeteKeyword = "top",
                Status = true
            };
            var item3 = new ProductCategory()
            {
                ProductCategoryID = 3,
                Name = "Bottom",
                MeteKeyword = "bottom",
                Status = true
            };
            var item4 = new ProductCategory()
            {
                ProductCategoryID = 4,
                Name = "Swimwear",
                MeteKeyword = "swimwear",
                Status = true
            };
            context.ProductCategories.Add(item1);
            context.ProductCategories.Add(item2);
            context.ProductCategories.Add(item3);
            context.ProductCategories.Add(item4);
        }
        private void AddProducts(ClothesBYWDbContext context)
        {
            var item1 = new Product()
            {
                ProductID = "sampleProduct1",
                ProductName = "Wondrous Water Lilies Royal Blue Maxi Dress",
                MetaKeyword = "sample-1",
                Description = "Take a moment to marvel at the sheer beauty of the Lulus Wondrous Water Lilies Royal Blue Maxi Dress! Royal blue chiffon shapes a surplice bodice framed by sheer long sleeves. A billowing maxi skirt with front slit falls below the elasticized waist for a stunning finish.",
                CreatedDate = DateTime.Now,
                CreatedBy = null,
                CategoryID = 1,
                BrandID = 1,
                Status = 1
            };
            var item2 = new Product()
            {
                ProductID = "sampleProduct2",
                ProductName = "Thoughts of Hue Black Surplice Maxi Dress",
                MetaKeyword = "sample-2",
                Description = "Lulus Exclusive! The Lulus Thoughts of Hue Black Surplice Maxi Dress will have you dreaming of romantic evenings under starlit skies! Lightweight woven Georgette fabric drapes into a sleeveless, surplice bodice and V-back, atop a banded waistline. Cascading skirt falls to a maxi hem with a sultry side slit. Hidden back zipper with clasp.",
                CreatedDate = DateTime.Now,
                CreatedBy = null,
                CategoryID = 1,
                BrandID = 2,
                Status = 1
            };
            var item3 = new Product()
            {
                ProductID = "sampleProduct3",
                ProductName = "Thoughts of Hue Black Surplice Maxi Dress",
                MetaKeyword = "sample-3",
                Description = "Lulus Exclusive! The Lulus Thoughts of Hue Black Surplice Maxi Dress will have you dreaming of romantic evenings under starlit skies! Lightweight woven Georgette fabric drapes into a sleeveless, surplice bodice and V-back, atop a banded waistline. Cascading skirt falls to a maxi hem with a sultry side slit. Hidden back zipper with clasp.",
                CreatedDate = DateTime.Now,
                CreatedBy = null,
                CategoryID = 1,
                BrandID = 3,
                Status = 1
            };
            var item4 = new Product()
            {
                ProductID = "sampleProduct4",
                ProductName = "Thoughts of Hue Black Surplice Maxi Dress",
                MetaKeyword = "sample-4",
                Description = "Take a moment to marvel at the sheer beauty of the Lulus Wondrous Water Lilies Royal Blue Maxi Dress! Royal blue chiffon shapes a surplice bodice framed by sheer long sleeves. A billowing maxi skirt with front slit falls below the elasticized waist for a stunning finish.",
                CreatedDate = DateTime.Now,
                CreatedBy = null,
                CategoryID = 1,
                BrandID = 4,
                Status = 1
            };
            var item5 = new Product()
            {
                ProductID = "sampleProduct5",
                ProductName = "Thoughts of Hue Black Surplice Maxi Dress",
                MetaKeyword = "sample-4",
                Description = "Take a moment to marvel at the sheer beauty of the Lulus Wondrous Water Lilies Royal Blue Maxi Dress! Royal blue chiffon shapes a surplice bodice framed by sheer long sleeves. A billowing maxi skirt with front slit falls below the elasticized waist for a stunning finish.",
                CreatedDate = DateTime.Now,
                CreatedBy = null,
                CategoryID = 1,
                BrandID = 4,
                Status = 1
            };
            context.Products.Add(item1);
            context.Products.Add(item2);
            context.Products.Add(item3);
            context.Products.Add(item4);
            context.Products.Add(item5);
        }
        private void AddSupplier(ClothesBYWDbContext context)
        {
            var item1 = new Supplier()
            {
                SupplierID = 1,
                Name = "Quang Chau 1",
                Email = "qc1@contact.com",
                Address = "Harvard Dong Da",
                ContactPerson = "Nguyen Le",
                PhoneContactPerson = "132003232",
                PhoneSupplier = "132003232",
            };
            var item2 = new Supplier()
            {
                SupplierID = 2,
                Name = "Quang Chau 2",
                Email = "qc1@contact.com",
                Address = "Harvard Dong Da",
                ContactPerson = "Nguyen Le",
                PhoneContactPerson = "132003232",
                PhoneSupplier = "132003232",
            };
            context.Suppliers.Add(item1);
            context.Suppliers.Add(item2);
        }
        private void AddProductLines(ClothesBYWDbContext context)
        {
            var listSize = new List<string>() { "S", "M", "L", "XL" };
            var setImg1 = new List<string>() { "1-0.jpg", "1-1.jpg", "1-2.ipg", "1-3.png", "1-4.png" };
            var setImg2 = new List<string>() { "2-0.png", "2-1.png", "2-2.png", "2-3.png", "2-4.png" };
            var product1line = new List<Tuple<int,List<string>>>() { new Tuple<int, List<string>>(1,setImg1), new Tuple<int, List<string>>(12,setImg2) };

            var setImg3 = new List<string>() { "3-0.png", "3-2.png", "3-3.png", "3-4.png", "3-5.jpg", "3-6.jpg", "3-7.jpg", "3-8.jpg" };
            var setImg4 = new List<string>() { "4-0.jpg", "4-1.jpg", "4-2.jpg", "4-3.jpg", "4-4.jpg", "4-5.png" };
            var setImg5 = new List<string>() { "5-0.jpg", "5-1.jpg", "5-2.jpg", "5-3.jpg", "5-4.jpg", "5-5.jpg", "5-6.jpg", "5-7.jpg" };
            var product2line = new List<Tuple<int, List<string>>>() { new Tuple<int, List<string>>(3,setImg3), new Tuple<int, List<string>>(4,setImg4), new Tuple<int, List<string>>(5,setImg5) };

            var setImg6 = new List<string>() { "6-0.png", "6-1.png", "6-2.png", "6-3.png" };
            var setImg7 = new List<string>() { "7-0.jpg", "7-1.jpg", "7-2.jpg", "7-3.jpg", "7-4.jpg", "7-5.jpg" };
            var product3line = new List<Tuple<int, List<string>>>() { new Tuple<int, List<string>>(6,setImg6), new Tuple<int, List<string>>(7,setImg7) };

            var setImg8 = new List<string>() { "8-0.png", "8-1.png", "8-2.png", "8-3.png", "8-4.png", "8-5.png", "8-6.png", "8-7.png", "8-8.png", "8-9.png" };
            var setImg9 = new List<string>() { "9-0.png", "9-1.png", "9-2.png", "9-3.png", "9-4.png" };
            var setImg10 = new List<string>() { "10-0.png", "10-1.png", "10-2.png", "10-3.png" };
            var product4line = new List<Tuple<int, List<string>>>() { new Tuple<int, List<string>>(8,setImg8), new Tuple<int, List<string>>(9,setImg9), new Tuple<int, List<string>>(10,setImg10) };

            var setImg11 = new List<string>() { "11-0.png", "11-1.jpg", "11-2.png", "11-3.png", "11-4.png" };
            var setImg12 = new List<string>() { "12-0.png", "12-1.png", "12-2.png", "12-3.png", "12-4.png" };
            var setImg13 = new List<string>() { "13-0.png", "13-1.png" };
            var product5line = new List<Tuple<int, List<string>>>() { new Tuple<int, List<string>>(11,setImg11), new Tuple<int, List<string>>(10,setImg12),new Tuple<int, List<string>>(2,setImg13) };
            var listproduct = new List<List<Tuple<int, List<string>>>>() { product1line, product2line, product3line, product4line, product5line };

            var index = 1;
            var productIndex = 1;
            var imageIndex = 1;
            foreach(var product in listproduct)
            {
                foreach(var line in product)
                {
                    foreach(var size in listSize)
                    {
                        var lineID = "sampleLine" + index.ToString();
                        context.ProductLines.Add(new ProductLine()
                        {
                            ProductLineID = lineID,
                            ProductID = "sampleProduct" + productIndex.ToString(),
                            Alias = "dress",
                            Status = 1,
                            Size = size,
                            MinimumQuantityAvailable = 1,
                            ColorID = line.Item1,
                            QuantityInStock = 20,
                            CreatedDate = DateTime.Now,
                            SupplierID = 1
                        });
                        foreach (var image in line.Item2)
                        {
                            context.ProductImages.Add(new ProductImage()
                            {
                                ProductImageID = imageIndex,
                                ProductLineID = lineID,
                                ImageLink = "/Assets/Client/img/Product/"+image
                            });
                        }
                        index++;
                    }
                }
                productIndex++;
            }
        }
        private void AddPrices(ClothesBYWDbContext context)
        {
            for(int i = 1; i <= 5; i++)
            {
                context.Prices.Add(new Price()
                {
                    PriceID = i,
                    ProductID = "sampleProduct" + i.ToString(),
                    WholeSalePrice = 50,
                    RetailPrice = 45,
                    StandardPrice = 45
                });
            }
        }
        private void AddVoucher(ClothesBYWDbContext context)
        {
            var item1 = new Voucher()
            {
                VoucherID = "",
                PercentageDiscount = 0,
                AmountDiscount = 0,
                CreatedDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                Status = 1
            };
            var item2 = new Voucher()
            {
                VoucherID = "VOUCET",
                PercentageDiscount = 10,
                AmountDiscount = 5,
                CreatedDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                Status = 1
            };
            context.Vouchers.Add(item1);
            context.Vouchers.Add(item2);
        }
        private void AddUserGroup(ClothesBYWDbContext context)
        {
            var item1 = new UserGroup()
            {
                UserGroupID = "ADMIN",
                Name = "Admin"
            };
            var item2 = new UserGroup()
            {
                UserGroupID = "CUSTOMER_CATEGORY",
                Name = "Nhân viên chăm sóc khách hàng"
            };
            var item3 = new UserGroup()
            {
                UserGroupID = "MANAGER",
                Name = "Quản lý"
            };
            var item4 = new UserGroup()
            {
                UserGroupID = "SALER",
                Name = "Nhân viên bán hàng"
            };
            var item5 = new UserGroup()
            {
                UserGroupID = "WAREHOUSE_STAFF",
                Name = "Nhân viên kho"
            };
            context.UserGroups.Add(item1);
            context.UserGroups.Add(item2);
            context.UserGroups.Add(item3);
            context.UserGroups.Add(item4);
            context.UserGroups.Add(item5);
        }
    }
}
