//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using eticaret_entity;
//using eticaret_entity.Models;

//namespace eticaret_data.Configurations
//{
//    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
//    {
//        public void Configure(EntityTypeBuilder<Category> builder)
//        {
//            builder.HasKey(m => m.Id);

//            //builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
//            builder.HasData(new Category() { Id = 1, Name = "Yağlı Boyalar" },
//             new Category() { Id = 2, Name = "Sulu Boyalar" },
//             new Category() { Id = 3, Name = "Minyatür" },
//             new Category() { Id = 4, Name = "Özgür Yapraklar" }
//             );

//        }
//    }
//}