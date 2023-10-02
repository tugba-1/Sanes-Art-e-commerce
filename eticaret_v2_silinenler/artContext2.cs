//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_v2
//{
//    public class ProductCategory
//    {
//        public int CategoryId { get; set; }
//        public string Name { get; set; }
//        public int ProductId { get; set; }
//    }
//    public class artContext2 : artContext
//    {
//        public DbSet<ProductCategory> ProductCategories { get; set; }
//        public artContext2()
//        {

//        }
//        public artContext2(DbContextOptions<artContext> options) : base()
//        {

//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<ProductCategory>(entity =>
//            {
//                entity.HasNoKey();
//            });
//        }
//    }
//}
