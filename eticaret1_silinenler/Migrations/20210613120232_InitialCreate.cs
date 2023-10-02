using Microsoft.EntityFrameworkCore.Migrations;

namespace eticaret1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoryys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoryys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Productt",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricee = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productt", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryyProductt",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProducttProductId = table.Column<int>(type: "int", nullable: true),
                    CategoryyCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryyProductt", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Categoryys_CategoryyCategoryId",
                        column: x => x.CategoryyCategoryId,
                        principalTable: "Categoryys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Productt_ProducttProductId",
                        column: x => x.ProducttProductId,
                        principalTable: "Productt",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_CategoryyCategoryId",
                table: "CategoryyProductt",
                column: "CategoryyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_ProducttProductId",
                table: "CategoryyProductt",
                column: "ProducttProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryyProductt");

            migrationBuilder.DropTable(
                name: "Categoryys");

            migrationBuilder.DropTable(
                name: "Productt");
        }
    }
}
