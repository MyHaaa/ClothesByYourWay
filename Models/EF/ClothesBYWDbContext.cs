using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public class ClothesBYWDbContext : DbContext
    {
        public ClothesBYWDbContext()
            : base("name=ClothesBYW")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryUni> DeliveryUnis { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductLine> ProductLines { get; set; }
        public virtual DbSet<ProductModification> ProductModifications { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PromotionProduct> PromotionProducts { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShipperOrder> ShipperOrders { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuration
            modelBuilder.Entity<Brand>().ToTable("Brands").HasKey(x => x.BrandID);

            modelBuilder.Entity<Color>().ToTable("Colors").HasKey(x => x.ColorID);

            modelBuilder.Entity<Credential>().ToTable("Credential").HasKey(x => x.CredentialID);
            modelBuilder.Entity<Credential>().HasRequired(x => x.Role).WithMany(x => x.Credentials).HasForeignKey(x => x.RoleID);
            modelBuilder.Entity<Credential>().HasRequired(x => x.UserGroup).WithMany(x => x.Credentials).HasForeignKey(x => x.UserGroupID);

            modelBuilder.Entity<Customer>().ToTable("Customers").HasKey(x => x.CustomerID);
            modelBuilder.Entity<Customer>().HasRequired(x => x.CustomerCategory).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerCatergoryID);

            modelBuilder.Entity<CustomerCategory>().ToTable("CustomerCategories").HasKey(x => x.CustomerCategoryID);

            modelBuilder.Entity<DeliveryUni>().ToTable("DeliveryUnis").HasKey(x => x.DeliveryUnitID);

            modelBuilder.Entity<Employee>().ToTable("Emoloyees").HasKey(x => x.EmployeeID);
            modelBuilder.Entity<Employee>().HasRequired(x => x.UserGroup).WithMany(x => x.Employees).HasForeignKey(x => x.UserGroupID);

            modelBuilder.Entity<Feedback>().ToTable("Feedbacks").HasKey(x => x.FeedBackID);
            modelBuilder.Entity<Feedback>().HasRequired(x => x.Customer).WithMany(x => x.Feedbacks).HasForeignKey(x => x.CustomerID);
            modelBuilder.Entity<Feedback>().HasRequired(x => x.Product).WithMany(x => x.Feedbacks).HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(x => x.OrderID);
            modelBuilder.Entity<Order>().HasRequired(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);
            modelBuilder.Entity<Order>().HasRequired(x => x.Voucher).WithMany(x => x.Orders).HasForeignKey(x => x.VoucherID);

            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails").HasKey(x => x.OrderDetailID);
            modelBuilder.Entity<OrderDetail>().HasRequired(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
            modelBuilder.Entity<OrderDetail>().HasRequired(x => x.ProductLine).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductLineID);

            modelBuilder.Entity<Price>().ToTable("Prices").HasKey(x => x.PriceID);
            modelBuilder.Entity<Price>().HasRequired(x => x.Product).WithMany(x => x.Prices).HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Product>().ToTable("Products").HasKey(x => x.ProductID);
            modelBuilder.Entity<Product>().HasRequired(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandID);
            modelBuilder.Entity<Product>().HasRequired(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories").HasKey(x => x.ProductCategoryID);

            modelBuilder.Entity<ProductImage>().ToTable("ProductImages").HasKey(x => x.ProductImageID);
            modelBuilder.Entity<ProductImage>().HasRequired(x => x.ProductLine).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductLineID);

            modelBuilder.Entity<ProductLine>().ToTable("ProductLines").HasKey(x => x.ProductLineID);
            modelBuilder.Entity<ProductLine>().HasRequired(x => x.Color).WithMany(x => x.ProductLines).HasForeignKey(x => x.ColorID);
            modelBuilder.Entity<ProductLine>().HasRequired(x => x.Product).WithMany(x => x.ProductLines).HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<ProductLine>().HasRequired(x => x.Supplier).WithMany(x => x.ProductLines).HasForeignKey(x => x.SupplierID);

            modelBuilder.Entity<ProductModification>().ToTable("ProductModifications").HasKey(x => x.PMID);
            modelBuilder.Entity<ProductModification>().HasRequired(x => x.Product).WithMany(x => x.ProductModifications).HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Promotion>().ToTable("Promotions").HasKey(x => x.PromotionID);

            modelBuilder.Entity<PromotionProduct>().ToTable("PromotionProducts").HasKey(x => x.PromotionProductID);
            modelBuilder.Entity<PromotionProduct>().HasRequired(x => x.Product).WithMany(x => x.PromotionProducts).HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<PromotionProduct>().HasRequired(x => x.Promotion).WithMany(x => x.PromotionProducts).HasForeignKey(x => x.PromotionID);

            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrders").HasKey(x => x.PurchaseOrderID);

            modelBuilder.Entity<PurchaseOrderDetail>().ToTable("PurchaseOrderDetails").HasKey(x => x.PurchaseOrderDetailID);
            modelBuilder.Entity<PurchaseOrderDetail>().HasRequired(x => x.ProductLine).WithMany(x => x.PurchaseOrderDetails).HasForeignKey(x => x.ProductLineID);
            modelBuilder.Entity<PurchaseOrderDetail>().HasRequired(x => x.PurchaseOrder).WithMany(x => x.PurchaseOrderDetails).HasForeignKey(x => x.PurchaseOrderID);

            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(x => x.RoleID);

            modelBuilder.Entity<Shipper>().ToTable("Shippers").HasKey(x => x.ShipperID);
            modelBuilder.Entity<Shipper>().HasRequired(x => x.DeliveryUni).WithMany(x => x.Shippers).HasForeignKey(x => x.DeliveryUnitID);

            modelBuilder.Entity<ShipperOrder>().ToTable("ShipperOrders").HasKey(x => x.ShipperOrderID);
            modelBuilder.Entity<ShipperOrder>().HasRequired(x => x.Order).WithMany(x => x.ShipperOrders).HasForeignKey(x => x.OrderID);
            modelBuilder.Entity<ShipperOrder>().HasRequired(x => x.Shipper).WithMany(x => x.ShipperOrders).HasForeignKey(x => x.ShipperID);

            modelBuilder.Entity<Supplier>().ToTable("Suppliers").HasKey(x => x.SupplierID);

            modelBuilder.Entity<sysdiagram>().ToTable("Sysdiagram").HasKey(x => x.diagram_id);

            modelBuilder.Entity<UserGroup>().ToTable("UserGroups").HasKey(x => x.UserGroupID);

            modelBuilder.Entity<Voucher>().ToTable("Voucher").HasKey(x => x.VoucherID);

            ModalSeedData.Seed(this);
        }
    }
}
