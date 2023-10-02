//using eticaret_data.Configurations;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class artContext : DbContext
    {
        public artContext()
        {

        }
        public artContext(DbContextOptions<artContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardItems> CardItems { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Comment> Comment { get; set; }
        //public DbSet<CommentUser> CommentUser { get; set; }
        public DbSet<Users> Users { get; set; }
        //public DbSet<ProductComment> ProductComment { get; set; }
        //public DbSet<ProductComment> ProductComment { get; set; }
        //public DbSet<Comment> Comment { get; set; }

        //public static readonly ILoggerFactory MyLoggerFactory
        //     = LoggerFactory.Create(Builder => { Builder.AddConsole(); });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=P3NWPLSK12SQL-v06.shr.prod.phx3.secureserver.net;Database=eticaret_v2;user=tugb;password=Az2580139_;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.ProductId, c.CategoryId });
            //modelBuilder.Entity<CommentUser>()
            //    .HasKey(c => new { c.CommentId, c.UserId });
            //modelBuilder.Entity<Comment>()
            //    .HasNoKey();
            //modelBuilder.Entity<ProductComment>()
            //.HasKey(c => new { c.CommentId, c.ProductId });

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //    modelBuilder.ApplyConfiguration(new CardConfiguration());
        //    modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

        //    //    modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

        //    //    //modelBuilder.Entity<Comment>()
        //    //    //    .HasNoKey();
        //    //    //modelBuilder.Entity<ProductComment>()
        //    //    //.HasKey(c => new { c.CommentId, c.ProductId });


        //    //modelBuilder.Seed();
        //}

        //public class Product
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public decimal? Price { get; set; }
        //    //public int CategoryId { get; set; }
        //    public Category Category { get; set; }
        //    public int CategoryId { get; set; }
        //    public Order Order { get; set; }
        //    public int OrderId { get; set; }
        //}
        //public class Category
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    //public int ProductId { get; set; }
        //    public List<Product> Products { get; set; }

        //}
        //public class Order
        //{
        //    public int Id { get; set; }
        //    public int SiparisNo { get; set; }
        //    public DateTime DateAdded { get; set; }
        //    public List<Product> Products { get; set; }
        //}
    }
}
