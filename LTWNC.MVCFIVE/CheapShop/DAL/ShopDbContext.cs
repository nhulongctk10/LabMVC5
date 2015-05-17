using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CheapShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CheapShop.DAL
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext()
            : base("CheapShop2")
        {
        }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //thiết lập tên cho các bảng lưu thông tin  người dùng và quyền
            modelBuilder.Entity<IdentityUser>().ToTable("Accounts");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserInRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");


            //thiết lập mối quan hệ cha con của Loại/Nhóm sản phẩm
            modelBuilder.Entity<Category>()
                .HasMany(c => c.ChildCates)
                .WithOptional(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .WillCascadeOnDelete(false);


            //thiết lập mối quan hệ nhiều-nhiều giửa loại-nhóm sản phẩm
            //và sản phẩm. Việc này sẽ tạo ra thêm một bảng mới có tên là
            //ProductCategory. Mỗi sản phẩm có thể thuộc vào nhiều nhóm khác nhau
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Category)
                .Map(m => m.MapLeftKey("CategoryId")
                    .MapRightKey("ProductId").ToTable("ProductCategory"));


            //thiết lập mối quan hệ giữa đơn hàng và chi tiết đơn hàng
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithRequired(d => d.Order)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa sản phẩm và chi tiết đơn hàng
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetail)
                .WithRequired(d => d.Product)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa công ty vận chuyển và đơn hàng
            modelBuilder.Entity<Shipper>()
                .HasMany(s => s.Orders)
                .WithOptional(o => o.Shipper)
                .HasForeignKey(o => o.ShipVia);

            //thiết lập mối quan hệ giữa nhà cung cấp và sản phầm
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithRequired(p => p.Supplier)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa tài khoản(Khách) và đơn hàng
            modelBuilder.Entity<Account>()
                .HasMany(a => a.BuyOrders)
                .WithRequired(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(false);

            //thiết lập mối quan hệ giữa tài khoản(Nhân viên) và đơn hàng
            modelBuilder.Entity<Account>()
                 .HasMany(a => a.HandleOrders)
                .WithRequired(o => o.Employee)
                .HasForeignKey(o => o.EmployeeId)
                .WillCascadeOnDelete(false);

            //thiết lập mối quan hệ giữa Product và ProductHistory
            modelBuilder.Entity<Product>()
                .HasMany(a=>a.ProductHistories)
                .WithRequired(c=>c.Product)
                .HasForeignKey(c=>c.ProductId)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa sản phẩm và bình luận
            modelBuilder.Entity<Product>()
                .HasMany(p=>p.Comments)
                .WithRequired(d=>d.Product)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa sản phẩm và hình ảnh
            modelBuilder.Entity<Product>()
                .HasMany(p=>p.Pictures)
                .WithRequired(p=>p.Product)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa tài khoản và bình luận
            modelBuilder.Entity<Account>()
                .HasMany(p=>p.Comments)
                .WithOptional(c=>c.Replier)
                .HasForeignKey(c=>c.AccountId)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa tài khoản và ProductHistory
            modelBuilder.Entity<Account>()
                .HasMany(a=>a.ProductHistories)
                .WithOptional(c=>c.Account)
                .HasForeignKey(c=>c.AccountId)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa Product va ProductProfile
            modelBuilder.Entity<Product>()
                .HasOptional(x => x.ProductProfiles)
                .WithRequired(p => p.Product);

            //thiết lập mối quan hệ giữa Product với Picture
            modelBuilder.Entity<Product>()
                .HasMany(p=>p.Pictures)
                .WithRequired(a=>a.Product)
                .WillCascadeOnDelete();

            //thiết lập mối quan hệ giữa Product với Comment
            modelBuilder.Entity<Product>()
                .HasMany(c=>c.Comments)
                .WithRequired(p=>p.Product)
                .WillCascadeOnDelete();

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<ProductProfile> ProductProfiles { get; set; }
    }
}