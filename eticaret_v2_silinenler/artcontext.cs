using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class artcontext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public static readonly ILoggerFactory MyLoggerFactory
             = LoggerFactory.Create(Builder => { Builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LMBQ9BU\SQLEXPRESS;Database=eticaret1;user=sa;password=1");
        }
    }
}
