using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data
{
    //public class artContext : DbContext
    //{
    //    //public DbSet<Product> Products { get; set; }
    //    //public DbSet<Category> Categorys { get; set; }
    //    //public DbSet<Order> Orders { get; set; }
    //    public static readonly ILoggerFactory MyLoggerFactory
    //         = LoggerFactory.Create(Builder => { Builder.AddConsole(); });
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer(@"Server=DESKTOP-LMBQ9BU\SQLEXPRESS;Database=eticaret1;user=sa;password=1");
    //    }
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

    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
