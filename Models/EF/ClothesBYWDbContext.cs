using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class ClothesBYWDbContext : DbContext
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
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.ImageBrand)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.Texture)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerCategory>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerCategory)
                .HasForeignKey(e => e.CustomerCatergoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryUni>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryUni>()
                .Property(e => e.PhoneContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryUni>()
                .Property(e => e.EmailContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CitizenID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderDetailID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductLineID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<Price>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Price>()
                .Property(e => e.WholeSalePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Price>()
                .Property(e => e.RetailPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MeteKeyword)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<ProductImage>()
                .Property(e => e.ProductLineID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductImage>()
                .Property(e => e.ImageLink)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.ProductLineID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductModification>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductModification>()
                .Property(e => e.ModifiledBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaKeyword)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductModifications)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PromotionProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromotionProduct>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.PromotionProducts)
                .WithRequired(e => e.Promotion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.PurchaseOrderDetailID)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.PurchaseOrderID)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.ProductLineID)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PurchaseOrderID)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.ModifiledBy)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<ShipperOrder>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<ShipperOrder>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<ShipperOrder>()
                .Property(e => e.ShipperID)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.ShipperID)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PhoneSupplier)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PhoneContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.UserGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Voucher>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);
        }
    }
}
