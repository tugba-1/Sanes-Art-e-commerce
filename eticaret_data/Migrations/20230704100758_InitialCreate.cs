using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eticaretdata.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisNo = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardItems_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "33863913-e083-4aa6-a32c-791b7ef6d78b" },
                    { 2, "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
                    { 3, "216b2e5b-8315-4d3e-bb01-9ebad2247fe6" },
                    { 4, "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
                    { 5, "b83bd353-9b07-4c8d-a411-da12b9056dec" },
                    { 6, "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
                    { 7, "5e909802-1002-4a33-9814-1d631f868477" },
                    { 8, "d72106cb-2701-4a83-9f47-ba6c5ac5ad7e" },
                    { 9, "03051276-2084-4f26-b792-ed2f57e92299" }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yağlı Boyalar" },
                    { 2, "Sulu Boyalar" },
                    { 3, "Minyatür" },
                    { 4, "Özgür Yapraklar" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 6, 39 },
                    { 6, 40 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CommentId", "Description", "ImgUrl", "IsApproved", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 7, "50 x 110 cm", "aa45abbb-7277-4c87-a41a-b20c1eec45cb.JPG", false, "Kız Kulesi", 1, 5m },
                    { 2, 5, 7, "45 x 60 cm", "abdff2f4-8939-4ec7-b922-647cfbb36bf3.JPG", false, "Yeşil Vadi", 1, 11m },
                    { 3, 1, 7, "50 x 70 cm", "7b6db39c-9f94-4551-b275-449f7ee93037.jpg", false, "Masal Köy", 1, 0m },
                    { 4, 3, 1, "45 x 60 cm", "cb556e34-2d3c-4c7b-96d4-86c54f49941c.jpg", false, "Yansıma", 1, 12m },
                    { 5, 3, 7, "20 x 27 cm", "5869b556-61f4-4996-96eb-4475abd7732a.jpg", false, "", 3, 15m },
                    { 6, 2, 0, "70 x 90 cm", "ce430118-3193-4630-a275-13e2347627c4.jpg", false, "Cimil Şelalesi", 1, 1m },
                    { 7, 1, 0, "40 x 50 cm", "d4b6317f-43e8-4a6a-bdec-234c2364aab9.JPG", false, "Taş Ev", 1, 1m },
                    { 8, 2, 0, "25 x 35 cm", "358b912f-4d57-4224-a98e-721755be87f0.png", false, "Mutluluk", 1, 1m },
                    { 9, 2, 0, "25 x 35 cm ", "78a3e257-b065-4079-879a-75a5ae602994.png", false, "Hülasa", 1, 1m },
                    { 10, 2, 0, "14 x 25 cm", "28de71f9-f5d3-47ec-8c27-245c87912f28.jpg", false, "Huzur", 1, 1m },
                    { 11, 0, 0, "84 x 84 cm", "5eb89005-113f-4326-89a1-1cca40931ef0.jpg", false, "Yaşam", 0, 1m },
                    { 12, 0, 0, "13 x 28 cm", "203833d3-57d9-496f-a829-abcfdcb78fec.jpg", false, "Denizciler", 0, 0m },
                    { 13, 0, 0, "22 x 22 cm", "e1b5682e-6086-4d9f-ac36-d4e4d6f7a033.jpg", false, "Semazen", 0, 0m },
                    { 14, 0, 0, "11 x 17 cm", "b59001a7-aab8-472d-b2e3-d9b05db19f2b.JPG", false, "Zeynep Dalkılıç", 0, 0m },
                    { 15, 0, 0, " 17 x 23 cm", "60c52500-a841-4f39-be06-77732fbb7969.jpg", false, "Zeynep Dalkılıç", 0, 0m },
                    { 16, 0, 0, "30 x 40 cm", "2abc375c-5c63-4ca4-930a-68a628087f0c.png", false, "Yayla Dönüşü ", 0, 0m },
                    { 17, 0, 0, "19 x 27 cm", "42edd97d-253b-47be-b86b-3edb0346ad73.JPG", false, "", 0, 0m },
                    { 18, 0, 0, "18 x 28 cm", "37320ca7-8d21-4023-bead-aa5aee654587.JPG", false, "", 0, 0m },
                    { 19, 0, 0, "16 x 18 cm", "0aae6fbc-7dd0-4bb7-a762-fb1188301060.JPG", false, "", 0, 0m },
                    { 20, 0, 0, "20 x 28 cm", "566ac9b7-193e-4382-a9f6-fa9d16867f21.JPG", false, "", 0, 0m },
                    { 21, 0, 0, "20 x 28 cm", "4dd23c1c-0bf4-4a55-a8f9-6f38d23b108a.JPG", false, "", 0, 0m },
                    { 22, 0, 0, "20 x 28 cm", "677bb0cf-9c2e-4f0a-bb18-f8ae2bec45d6.jpg", false, "", 0, 0m },
                    { 23, 0, 0, "20 x 28 cm", "702367da-fe4c-428a-ba34-f9ec15da10ff.JPG", false, "", 0, 0m },
                    { 24, 0, 0, "9 x 17 cm", "dd951ccd-ee9d-43e4-a56c-c8f9915a9ce1.jpg", false, "Atatürk", 0, 0m },
                    { 25, 0, 0, "17 x 9 cm", "32deb1e6-aeb0-4f58-8e8d-e09bb2d44113.png", false, "Semazen", 0, 0m },
                    { 26, 0, 0, " 14 x 14 cm ", "f939f232-fdce-477d-b1c4-29f5b647fbe8.jpg", false, "Mimber", 0, 0m },
                    { 27, 0, 0, " 12 x 18 cm", "0c8d5241-e343-4b5a-8880-02147ec3597a.jpg", false, "Teslimiyet", 0, 0m },
                    { 28, 0, 0, "8 x 12.5 cm", "a360282b-d810-444a-8e55-680a523249d9.jpg", false, "Mevlana", 0, 0m },
                    { 29, 0, 0, "40 x 50 cm", "7b24f31d-477c-44b6-92ee-2c1be604925b.jpg", false, "Hatice Hala", 0, 0m },
                    { 30, 0, 0, "17 x 24 cm", " 6e40a0c6-8940-4938-a07b-b2c3eb1d105b.JPG", false, "Sahan", 0, 0m },
                    { 31, 0, 0, " 35 x 50 cm", "7334d590-c32f-4977-b846-bce5ecc6ecc5.JPG", false, "Dağ Çiçeği", 0, 0m },
                    { 32, 0, 0, "15 x 25 cm", "dbc75cc7-6565-455b-aa4a-5bb02722b8e6.png", false, "Nilüfer", 0, 0m },
                    { 33, 0, 0, "30 x 50 cm", "b01aa988-cd47-4b6b-b3b6-f7fc71434713.png", false, "İnziva", 0, 0m },
                    { 34, 0, 0, "25 x 35 cm", "c309a7a9-2e36-4fe3-929a-5f066a1c6771.jpg", false, "Köy Yolu", 0, 0m },
                    { 35, 0, 0, "40 x 50 cm", "IMG_6751.jpg", false, "Safranbolu", 0, 0m },
                    { 36, 0, 0, "9 x 15 cm", "de049298-7c30-4741-ab21-111143a4af17.png", false, "Ayasofya", 0, 0m },
                    { 37, 0, 0, "9 x 16 cm", "e28d78f2-5b61-4823-999a-fd4052a41f83.png", false, "Kelebek", 0, 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 2, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 21 },
                    { 3, 22 },
                    { 3, 23 },
                    { 3, 24 },
                    { 3, 25 },
                    { 6, 26 },
                    { 6, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 2, 31 },
                    { 3, 32 },
                    { 2, 33 },
                    { 2, 34 },
                    { 2, 35 },
                    { 2, 37 },
                    { 2, 38 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardItems_CardId",
                table: "CardItems",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardItems_ProductId",
                table: "CardItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardItems");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
