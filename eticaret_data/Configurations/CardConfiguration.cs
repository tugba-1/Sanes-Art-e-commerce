//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using eticaret_entity;
//using eticaret_entity.Models;

//namespace eticaret_data.Configurations
//{
//    public class CardConfiguration : IEntityTypeConfiguration<Card>
//    {
//        public void Configure(EntityTypeBuilder<Card> builder)
//        {
//            builder.HasKey(m => m.Id);
//            builder.HasData(
//            new Card() { Id = 1, UserId = "33863913-e083-4aa6-a32c-791b7ef6d78b" },
//            new Card() { Id = 2, UserId = "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
//            new Card() { Id = 3, UserId = "216b2e5b-8315-4d3e-bb01-9ebad2247fe6" },
//            new Card() { Id = 4, UserId = "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
//            new Card() { Id = 5, UserId = "b83bd353-9b07-4c8d-a411-da12b9056dec" },
//            new Card() { Id = 6, UserId = "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
//            new Card() { Id = 7, UserId = "5e909802-1002-4a33-9814-1d631f868477" },
//            new Card() { Id = 8, UserId = "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
//            new Card() { Id = 9, UserId = "03051276-2084-4f26-b792-ed2f57e92299" }
//            );


//        }
//    }
//}