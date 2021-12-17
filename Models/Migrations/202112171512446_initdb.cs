namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        ImageBrand = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        MetaKeyword = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedBackID = c.Long(nullable: false, identity: true),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        Star = c.Int(),
                        Title = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.FeedBackID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        DateOfBirth = c.DateTime(),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        CreateDated = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        ModifiledDate = c.DateTime(),
                        CustomerCatergoryID = c.Int(nullable: false),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.CustomerCategories", t => t.CustomerCatergoryID, cascadeDelete: true)
                .Index(t => t.CustomerCatergoryID);
            
            CreateTable(
                "dbo.CustomerCategories",
                c => new
                    {
                        CustomerCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CustomerCategoryID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 128),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        AddressShip = c.String(),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Note = c.String(),
                        CreateDate = c.DateTime(),
                        Status = c.Int(),
                        VoucherID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Voucher", t => t.VoucherID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.VoucherID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.String(nullable: false, maxLength: 128),
                        OrderID = c.String(nullable: false, maxLength: 128),
                        PriceEach = c.Decimal(precision: 18, scale: 2),
                        ProductLineID = c.String(nullable: false, maxLength: 128),
                        QuantitySold = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.ProductLines", t => t.ProductLineID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductLineID);
            
            CreateTable(
                "dbo.ProductLines",
                c => new
                    {
                        ProductLineID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        Alias = c.String(),
                        Status = c.Int(),
                        Size = c.String(),
                        MinimumQuantityAvailable = c.Int(),
                        ColorID = c.Int(nullable: false),
                        QuantityInStock = c.Long(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductLineID)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ColorID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                        Texture = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageID = c.Long(nullable: false, identity: true),
                        ProductLineID = c.String(nullable: false, maxLength: 128),
                        ImageLink = c.String(),
                    })
                .PrimaryKey(t => t.ProductImageID)
                .ForeignKey("dbo.ProductLines", t => t.ProductLineID, cascadeDelete: true)
                .Index(t => t.ProductLineID);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        PurchaseOrderDetailID = c.String(nullable: false, maxLength: 128),
                        PurchaseOrderID = c.String(nullable: false, maxLength: 128),
                        ProductLineID = c.String(nullable: false, maxLength: 128),
                        QuantityPurchase = c.Long(),
                        QuantityReceived = c.Long(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderDetailID)
                .ForeignKey("dbo.ProductLines", t => t.ProductLineID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderID, cascadeDelete: true)
                .Index(t => t.PurchaseOrderID)
                .Index(t => t.ProductLineID);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderID = c.String(nullable: false, maxLength: 128),
                        TotalAmountPurchase = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiledDate = c.DateTime(),
                        ModifiledBy = c.String(),
                        ReceivedDate = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        PhoneSupplier = c.String(),
                        PhoneContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.ShipperOrders",
                c => new
                    {
                        ShipperOrderID = c.Int(nullable: false, identity: true),
                        OrderID = c.String(nullable: false, maxLength: 128),
                        EmployeeID = c.String(),
                        ShipperID = c.String(nullable: false, maxLength: 128),
                        DeliveryDatetime = c.DateTime(),
                        DeliveryNote = c.String(),
                    })
                .PrimaryKey(t => t.ShipperOrderID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ShipperID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        DeliveryUnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperID)
                .ForeignKey("dbo.DeliveryUnis", t => t.DeliveryUnitID, cascadeDelete: true)
                .Index(t => t.DeliveryUnitID);
            
            CreateTable(
                "dbo.DeliveryUnis",
                c => new
                    {
                        DeliveryUnitID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        PhoneContactPerson = c.String(),
                        EmailContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryUnitID);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        VoucherID = c.String(nullable: false, maxLength: 128),
                        PercentageDiscount = c.Decimal(precision: 18, scale: 2),
                        AmountDiscount = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        WholeSalePrice = c.Decimal(precision: 18, scale: 2),
                        RetailPrice = c.Decimal(precision: 18, scale: 2),
                        StandardPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MeteKeyword = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductModifications",
                c => new
                    {
                        PMID = c.Long(nullable: false, identity: true),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ModifiledBy = c.String(),
                        ModifiledDate = c.DateTime(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.PMID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.PromotionProducts",
                c => new
                    {
                        PromotionProductID = c.Long(nullable: false, identity: true),
                        PromotionID = c.Long(nullable: false),
                        ProductID = c.String(nullable: false, maxLength: 128),
                        EachPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PromotionProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionID, cascadeDelete: true)
                .Index(t => t.PromotionID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionID = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        PercentageDiscountSupplier = c.Decimal(precision: 18, scale: 2),
                        PercentageDiscountApproval = c.Decimal(precision: 18, scale: 2),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PromotionID);
            
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        CredentialID = c.Int(nullable: false, identity: true),
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        RoleID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CredentialID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserGroupID);
            
            CreateTable(
                "dbo.Emoloyees",
                c => new
                    {
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        DateOfBirth = c.DateTime(),
                        CitizenID = c.String(),
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        CreateDated = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID);
            
            CreateTable(
                "dbo.Sysdiagram",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credential", "UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.Emoloyees", "UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.Credential", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.PromotionProducts", "PromotionID", "dbo.Promotions");
            DropForeignKey("dbo.PromotionProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductModifications", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Prices", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "VoucherID", "dbo.Voucher");
            DropForeignKey("dbo.ShipperOrders", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.Shippers", "DeliveryUnitID", "dbo.DeliveryUnis");
            DropForeignKey("dbo.ShipperOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductLineID", "dbo.ProductLines");
            DropForeignKey("dbo.ProductLines", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderDetails", "ProductLineID", "dbo.ProductLines");
            DropForeignKey("dbo.ProductImages", "ProductLineID", "dbo.ProductLines");
            DropForeignKey("dbo.ProductLines", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductLines", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CustomerCatergoryID", "dbo.CustomerCategories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Emoloyees", new[] { "UserGroupID" });
            DropIndex("dbo.Credential", new[] { "RoleID" });
            DropIndex("dbo.Credential", new[] { "UserGroupID" });
            DropIndex("dbo.PromotionProducts", new[] { "ProductID" });
            DropIndex("dbo.PromotionProducts", new[] { "PromotionID" });
            DropIndex("dbo.ProductModifications", new[] { "ProductID" });
            DropIndex("dbo.Prices", new[] { "ProductID" });
            DropIndex("dbo.Shippers", new[] { "DeliveryUnitID" });
            DropIndex("dbo.ShipperOrders", new[] { "ShipperID" });
            DropIndex("dbo.ShipperOrders", new[] { "OrderID" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "ProductLineID" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderID" });
            DropIndex("dbo.ProductImages", new[] { "ProductLineID" });
            DropIndex("dbo.ProductLines", new[] { "SupplierID" });
            DropIndex("dbo.ProductLines", new[] { "ColorID" });
            DropIndex("dbo.ProductLines", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductLineID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "VoucherID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CustomerCatergoryID" });
            DropIndex("dbo.Feedbacks", new[] { "ProductID" });
            DropIndex("dbo.Feedbacks", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Sysdiagram");
            DropTable("dbo.Emoloyees");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Roles");
            DropTable("dbo.Credential");
            DropTable("dbo.Promotions");
            DropTable("dbo.PromotionProducts");
            DropTable("dbo.ProductModifications");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Prices");
            DropTable("dbo.Voucher");
            DropTable("dbo.DeliveryUnis");
            DropTable("dbo.Shippers");
            DropTable("dbo.ShipperOrders");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Colors");
            DropTable("dbo.ProductLines");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.CustomerCategories");
            DropTable("dbo.Customers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
