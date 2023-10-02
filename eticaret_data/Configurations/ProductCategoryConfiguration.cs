//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using eticaret_entity;
//using eticaret_entity.Models;
//using System.Reflection.Emit;

//namespace eticaret_data.Configurations
//{
//    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
//    {
//        public void Configure(EntityTypeBuilder<ProductCategory> builder)
//        {
//            builder.HasKey(c => new { c.ProductId, c.CategoryId });
//            //builder.Entity<CommentUser>()
//            //    .HasKey(c => new { c.CommentId, c.UserId });
//            //builder.HasKey(c => new { c.CategoryId, c.ProductId });
//            builder.HasData(new ProductCategory() { ProductId = 2, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 3, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 4, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 5, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 8, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 9, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 10, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 11, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 18, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 31, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 33, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 34, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 35, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 37, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 38, CategoryId = 2 },
//                            new ProductCategory() { ProductId = 6, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 19, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 20, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 21, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 22, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 23, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 24, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 25, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 32, CategoryId = 3 },
//                            new ProductCategory() { ProductId = 12, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 13, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 14, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 15, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 16, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 17, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 28, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 29, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 30, CategoryId = 4 },
//                            new ProductCategory() { ProductId = 26, CategoryId = 6 },
//                            new ProductCategory() { ProductId = 27, CategoryId = 6 },
//                            new ProductCategory() { ProductId = 39, CategoryId = 6 },
//                            new ProductCategory() { ProductId = 40, CategoryId = 6 }
//);
//        }
//    }
//}