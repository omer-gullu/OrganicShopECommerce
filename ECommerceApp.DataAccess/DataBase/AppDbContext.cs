using ECommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.DataBase
{
        public class AppDbContext : DbContext
        {
            // 📌 Constructor – DI (Dependency Injection) ile context ayarlarını alır
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {

            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8AVNO4L\\SQLEXPRESS;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        // 📦 Veritabanı tablolarını temsil eden DbSet'ler
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // ⚙️ Model oluşturulurken yapılandırmalar
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Product
                modelBuilder.Entity<Product>(entity =>
                {
                    entity.Property(p => p.Name)
                          .IsRequired()
                          .HasMaxLength(200);

                    entity.Property(p => p.Price)
                          .HasColumnType("decimal(18,2)");

                    entity.HasOne(p => p.Category)
                          .WithMany(c => c.Products)
                          .HasForeignKey(p => p.CategoryId)
                          .OnDelete(DeleteBehavior.Cascade);
                });

                // Category
                modelBuilder.Entity<Category>(entity =>
                {
                    entity.Property(c => c.Name)
                          .IsRequired()
                          .HasMaxLength(100);
                });
            // --- Basket - BasketItem ilişkisi (1 sepet -> N ürün)
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // --- User - Basket ilişkisi (1 kullanıcı -> 1 sepet)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Basket)
                .WithOne()
                .HasForeignKey<Basket>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- User - Order ilişkisi (1 kullanıcı -> N sipariş)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Order - OrderItem ilişkisi (1 sipariş -> N ürün)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // --- Decimal hassasiyet ayarı (SQL tarafında)
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Örnek veri ekleme (isteğe bağlı - seed data)
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Fruits & Veges" },
                    new Category { Id = 2, Name = "Breads & Sweets" },
                    new Category { Id = 3, Name = "Beverages" },
                    new Category { Id = 4, Name = "Meat Products" }
                );

                modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Organic Baby Spinach", Price = 18, CategoryId = 1, InStock = true, ImageUrl = "/images/product-thumb-10.png" },
                    new Product { Id = 2, Name = "Whole Wheat Sandwich Bread", Price = 24, CategoryId = 2, InStock = true, ImageUrl = "/images/product-thumb-17.png" },
                    new Product { Id = 3, Name = "Pure Squeezed Orange Juice", Price = 12, CategoryId = 3, InStock = true, ImageUrl = "/images/product-thumb-11.png" },
                    new Product { Id = 4, Name = "Fresh Salmon", Price = 50, CategoryId = 4, InStock = false, ImageUrl = "/images/product-thumb-6.png" }
                );
            }
        }
    }


