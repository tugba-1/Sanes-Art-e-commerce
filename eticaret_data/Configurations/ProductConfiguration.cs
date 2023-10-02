//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using eticaret_entity;
//using eticaret_entity.Models;

//namespace eticaret_data.Configurations
//{
//    public class ProductConfiguration : IEntityTypeConfiguration<Product>
//    {
//        public void Configure(EntityTypeBuilder<Product> builder)
//        {
//            builder.HasKey(m => m.Id);

//            //builder.Property(m => m.Name).IsRequired().HasMaxLength(100);

//            //builder.Property(m => m.DateAdded).HasDefaultValueSql("getdate()");  // mssql

//            builder.HasData(
//                new Product() { Id = 1, Name = "Kız Kulesi", Price = 5, ImgUrl = "aa45abbb-7277-4c87-a41a-b20c1eec45cb.JPG", CategoryId = 1, OrderId = 1, IsApproved = false, Description = "50 x 110 cm", CommentId = 7 },
//                new Product() { Id = 2, Name = "Yeşil Vadi", Price = 11, ImgUrl = "abdff2f4-8939-4ec7-b922-647cfbb36bf3.JPG", CategoryId = 5, OrderId = 1, IsApproved = false, Description = "45 x 60 cm", CommentId = 7 },
//                new Product() { Id = 3, Name = "Masal Köy", Price = 0, ImgUrl = "7b6db39c-9f94-4551-b275-449f7ee93037.jpg", CategoryId = 1, OrderId = 1, IsApproved = false, Description = "50 x 70 cm", CommentId = 7 },
//                new Product() { Id = 4, Name = "Yansıma", Price = 12, ImgUrl = "cb556e34-2d3c-4c7b-96d4-86c54f49941c.jpg", CategoryId = 3, OrderId = 1, IsApproved = false, Description = "45 x 60 cm", CommentId = 1 },
//                new Product() { Id = 5, Name = "", Price = 15, ImgUrl = "5869b556-61f4-4996-96eb-4475abd7732a.jpg", CategoryId = 3, OrderId = 3, IsApproved = false, Description = "20 x 27 cm", CommentId = 7 },
//                new Product() { Id = 6, Name = "Cimil Şelalesi", Price = 1, ImgUrl = "ce430118-3193-4630-a275-13e2347627c4.jpg", CategoryId = 2, OrderId = 1, IsApproved = false, Description = "70 x 90 cm", CommentId = 0 },
//                new Product() { Id = 7, Name = "Taş Ev", Price = 1, ImgUrl = "d4b6317f-43e8-4a6a-bdec-234c2364aab9.JPG", CategoryId = 1, OrderId = 1, IsApproved = false, Description = "40 x 50 cm", CommentId = 0 },
//                new Product() { Id = 8, Name = "Mutluluk", Price = 1, ImgUrl = "358b912f-4d57-4224-a98e-721755be87f0.png", CategoryId = 2, OrderId = 1, IsApproved = false, Description = "25 x 35 cm", CommentId = 0 },
//                new Product() { Id = 9, Name = "Hülasa", Price = 1, ImgUrl = "78a3e257-b065-4079-879a-75a5ae602994.png", CategoryId = 2, OrderId = 1, IsApproved = false, Description = "25 x 35 cm ", CommentId = 0 },
//                new Product() { Id = 10, Name = "Huzur", Price = 1, ImgUrl = "28de71f9-f5d3-47ec-8c27-245c87912f28.jpg", CategoryId = 2, OrderId = 1, IsApproved = false, Description = "14 x 25 cm", CommentId = 0 },
//                new Product() { Id = 11, Name = "Yaşam", Price = 1, ImgUrl = "5eb89005-113f-4326-89a1-1cca40931ef0.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "84 x 84 cm", CommentId = 0 },
//                new Product() { Id = 12, Name = "Denizciler", Price = 0, ImgUrl = "203833d3-57d9-496f-a829-abcfdcb78fec.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "13 x 28 cm", CommentId = 0 },
//                new Product() { Id = 13, Name = "Semazen", Price = 0, ImgUrl = "e1b5682e-6086-4d9f-ac36-d4e4d6f7a033.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "22 x 22 cm", CommentId = 0 },
//                new Product() { Id = 14, Name = "Zeynep Dalkılıç", Price = 0, ImgUrl = "b59001a7-aab8-472d-b2e3-d9b05db19f2b.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "11 x 17 cm", CommentId = 0 },
//                new Product() { Id = 15, Name = "Zeynep Dalkılıç", Price = 0, ImgUrl = "60c52500-a841-4f39-be06-77732fbb7969.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = " 17 x 23 cm", CommentId = 0 },
//                new Product() { Id = 16, Name = "Yayla Dönüşü ", Price = 0, ImgUrl = "2abc375c-5c63-4ca4-930a-68a628087f0c.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "30 x 40 cm", CommentId = 0 },
//                new Product() { Id = 17, Name = "", Price = 0, ImgUrl = "42edd97d-253b-47be-b86b-3edb0346ad73.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "19 x 27 cm", CommentId = 0 },
//                new Product() { Id = 18, Name = "", Price = 0, ImgUrl = "37320ca7-8d21-4023-bead-aa5aee654587.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "18 x 28 cm", CommentId = 0 },
//                new Product() { Id = 19, Name = "", Price = 0, ImgUrl = "0aae6fbc-7dd0-4bb7-a762-fb1188301060.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "16 x 18 cm", CommentId = 0 },
//                new Product() { Id = 20, Name = "", Price = 0, ImgUrl = "566ac9b7-193e-4382-a9f6-fa9d16867f21.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "20 x 28 cm", CommentId = 0 },
//                new Product() { Id = 21, Name = "", Price = 0, ImgUrl = "4dd23c1c-0bf4-4a55-a8f9-6f38d23b108a.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "20 x 28 cm", CommentId = 0 },
//                new Product() { Id = 22, Name = "", Price = 0, ImgUrl = "677bb0cf-9c2e-4f0a-bb18-f8ae2bec45d6.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "20 x 28 cm", CommentId = 0 },
//                new Product() { Id = 23, Name = "", Price = 0, ImgUrl = "702367da-fe4c-428a-ba34-f9ec15da10ff.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "20 x 28 cm", CommentId = 0 },
//                new Product() { Id = 24, Name = "Atatürk", Price = 0, ImgUrl = "dd951ccd-ee9d-43e4-a56c-c8f9915a9ce1.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "9 x 17 cm", CommentId = 0 },
//                new Product() { Id = 25, Name = "Semazen", Price = 0, ImgUrl = "32deb1e6-aeb0-4f58-8e8d-e09bb2d44113.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "17 x 9 cm", CommentId = 0 },
//                new Product() { Id = 26, Name = "Mimber", Price = 0, ImgUrl = "f939f232-fdce-477d-b1c4-29f5b647fbe8.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = " 14 x 14 cm ", CommentId = 0 },
//                new Product() { Id = 27, Name = "Teslimiyet", Price = 0, ImgUrl = "0c8d5241-e343-4b5a-8880-02147ec3597a.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = " 12 x 18 cm", CommentId = 0 },
//                new Product() { Id = 28, Name = "Mevlana", Price = 0, ImgUrl = "a360282b-d810-444a-8e55-680a523249d9.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "8 x 12.5 cm", CommentId = 0 },
//                new Product() { Id = 29, Name = "Hatice Hala", Price = 0, ImgUrl = "7b24f31d-477c-44b6-92ee-2c1be604925b.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "40 x 50 cm", CommentId = 0 },
//                new Product() { Id = 30, Name = "Sahan", Price = 0, ImgUrl = " 6e40a0c6-8940-4938-a07b-b2c3eb1d105b.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "17 x 24 cm", CommentId = 0 },
//                new Product() { Id = 31, Name = "Dağ Çiçeği", Price = 0, ImgUrl = "7334d590-c32f-4977-b846-bce5ecc6ecc5.JPG", CategoryId = 0, OrderId = 0, IsApproved = false, Description = " 35 x 50 cm", CommentId = 0 },
//                new Product() { Id = 32, Name = "Nilüfer", Price = 0, ImgUrl = "dbc75cc7-6565-455b-aa4a-5bb02722b8e6.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "15 x 25 cm", CommentId = 0 },
//                new Product() { Id = 33, Name = "İnziva", Price = 0, ImgUrl = "b01aa988-cd47-4b6b-b3b6-f7fc71434713.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "30 x 50 cm", CommentId = 0 },
//                new Product() { Id = 34, Name = "Köy Yolu", Price = 0, ImgUrl = "c309a7a9-2e36-4fe3-929a-5f066a1c6771.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "25 x 35 cm", CommentId = 0 },
//                new Product() { Id = 35, Name = "Safranbolu", Price = 0, ImgUrl = "IMG_6751.jpg", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "40 x 50 cm", CommentId = 0 },
//                new Product() { Id = 36, Name = "Ayasofya", Price = 0, ImgUrl = "de049298-7c30-4741-ab21-111143a4af17.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "9 x 15 cm", CommentId = 0 },
//                new Product() { Id = 37, Name = "Kelebek", Price = 0, ImgUrl = "e28d78f2-5b61-4823-999a-fd4052a41f83.png", CategoryId = 0, OrderId = 0, IsApproved = false, Description = "9 x 16 cm", CommentId = 0 });

//        }
//    }
//}