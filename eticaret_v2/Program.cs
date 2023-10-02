//using eticaret_v2.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using eticaret_v2.Extensions;
namespace eticaret_v2
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
            CreateHostBuilder(args).Build()
                //.MigrateDatabase()
                .Run();
            //AddProducts();

        //    using (var db = new artContext())
        //    //{
        //    //    var p = db.Products.Select(b=>new {b.Name, b.Price });
        //    //    foreach (var i in p)
        //    //    {
        //    //        Console.WriteLine(i.Name + " " + i.Price);
        //    //    }
        //    //}
        //    //{
        //    //    var p = db.Products
        //    //        .Where(i => i.Order.Products.Count() > 1)
        //    //        .Select(i => new Category
        //    //        {
        //    //            //Name = i.Name,   // Foreign key olmadığı için boş geliyor. 
        //    //            Id = i.CategoryId
        //    //        });
        //    //    foreach(var i in p)
        //    //    {
        //    //        Console.WriteLine(i.Id);
        //    //    }
        //    //}
        //    //{
        //    //    var p = db.Products
        //    //            .FromSqlRaw("select * from Products where Name = 'resim1'").ToList();
        //    //    foreach (var pp in p)
        //    //    {
        //    //        Console.WriteLine(pp.Name);
        //    //    }
        //    //};
        //    using (var dbb = new artContext2())
        //    {
        //        var c = dbb.ProductCategories.FromSqlRaw("select c.Id as CategoryId, p.Name, p.Id as ProductId from Products p join Categorys c on c.Id = p.CategoryId where c.Name = 'Karadeniz'").ToList();
        //        foreach (var cc in c)
        //        {
        //            Console.WriteLine(cc.Name);
        //        }
        //    }
        //}
        //static void AddProducts()
        //{
        //    using (var db = new artContext())
        //    {
        //        var p = new List<Order>
        //        {
        //            new Order { SiparisNo = 1, DateAdded = DateTime.Today },
        //            new Order { SiparisNo = 2, DateAdded = DateTime.Today }
        //        };
        //        foreach (var i in p)
        //        {
        //            db.Orders.Add(i);
        //        }
        //        var category = new List<Category>()
        //        {
        //            new Category {Name = "Karadeniz"},
        //            new Category {Name="Karma"}
        //        };
        //        foreach(var ii in category)
        //        {
        //            db.Categorys.Add(ii);
        //        }
        //        var products = new List<Product>()
        //        {
        //           new Product { Name = "resim1", Price = 5, CategoryId = 1, OrderId = 1},
        //           new Product { Name = "resim2", Price = 8, CategoryId = 2, OrderId = 1 },
        //           new Product { Name = "resim3", Price = 7 , CategoryId = 1, OrderId = 2 }
        //        };
        //        foreach (var i in products)
        //        {
        //            db.Products.Add(i);
        //        }
        //        //db.Products.AddRange(products);
        //        db.SaveChanges();
        //        Console.WriteLine("Veriler eklendi.");
        //    }
        //}

        ////static void AddProductOrder()
        ////{
        ////    using (var db = new artContext())
        ////    {
        ////        var products = new List<Product>()
        ////        {
        ////           new Product { OrderId = 1},
        ////           new Product { OrderId = 1 },
        ////           new Product { OrderId = 2}
        ////        };
        ////        foreach (var i in products)
        ////        {
        ////            db.Products.Add(i);
        ////        }
        ////        //db.Products.AddRange(products);
        ////        db.SaveChanges();
        ////        Console.WriteLine("Veriler eklendi.");
        ////    }
        ////}

        //static void AddProduct()
        //{
        //    using (var db = new artContext())
        //    {
        //        var p = new Product { Name = "resim4", Price = 10 };
                
        //        db.Add(p);
        //        db.SaveChanges();
        //        Console.WriteLine("Veriler eklendi.");
        //    }
        //}
        //static void AddOrders()
        //{
        //    using (var db = new artContext())
        //    {

        //        db.SaveChanges();
        //        Console.WriteLine("Veriler eklendi.");
        //    }
        //}
        //static void GetAllProducts()
        //{
        //    using (var db = new artContext())
        //    {
        //        var products = db.
        //            Products
        //            //.Select(p => 
        //            //    new
        //            //    {
        //            //        p.Name
        //            //    }
        //            //)
        //            .ToList();
        //        foreach (var i in products)
        //        {
        //            Console.WriteLine($"Name: {i.Name} Price : {i.Price}");
        //        }
        //        //db.Products.AddRange(products);
        //        db.SaveChanges();
        //        Console.WriteLine("Veriler eklendi.");
        //    }
        //}
        //static void GetById(int id)
        //{
        //    using (var db = new artContext())
        //    {
        //        var products = db.
        //            Products
        //            .Where(p => p.Id == id)
        //            .FirstOrDefault();

        //            Console.WriteLine($"Name: {products.Name} Price : {products.Price}");

        //        //db.Products.AddRange(products);
        //        //db.SaveChanges();
        //        //Console.WriteLine("Veriler eklendi.");
        //    }
        //}
        //static void GetByName(string name)
        //{
        //    using (var db = new artContext())
        //    {
        //        var products = db.Products
        //            .Where(p => p.Name.Contains(name.ToLower()))
        //            .ToList();
        //        foreach(var i in products)
        //        Console.WriteLine($"Name: {i.Name} Price : {i.Price}");

        //        //db.Products.AddRange(products);
        //        //db.SaveChanges();
        //        //Console.WriteLine("Veriler eklendi.");
        //    }
        //}
        //static void Update()
        //{
        //    using (var db = new artContext())
        //    {
        //        //var p = db.Products.Where(i => i.Id == 2).FirstOrDefault();
        //        //p.Price *= 1.2m;
        //        //db.SaveChanges();

        //        //var entity = new Product() { Id = 1 };
        //        //db.Products.Attach(entity);
        //        //entity.Price = 30;
        //        //db.SaveChanges();

        //        var p = db.Products.Where(i => i.Id ==1).FirstOrDefault();
        //        if (p != null)
        //        {
        //            p.OrderId = 1;
        //            db.Products.Update(p);
        //            db.SaveChanges();
        //            //Update hepsini güncelliyor
        //        }
        //    }
        //}

        //static void Delete(int id)
        //{
        //    using (var db = new artContext())
        //    {
        //        var p = new Product() {Id = 6 };
        //        db.Entry(p).State = EntityState.Deleted; //select sorgusu yok
        //        db.SaveChanges();
        //    }                
        //    //using (var db = new artContext())
        //    //{
        //    //    var p = db.Products.FirstOrDefault(i => i.Id == id);
        //    //    if(p != null)
        //    //    {
        //    //        db.Remove(p);
        //    //        db.SaveChanges();
        //    //    }
        //    //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //.CaptureStartupErrors(true)
                    //.UseSetting("detailedErrors","true");
                    //webBuilder.ConfigureLogging((ctx, logging) =>
                    //{
                    //});
                });
    }
}
