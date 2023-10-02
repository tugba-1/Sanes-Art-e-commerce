using Microsoft.EntityFrameworkCore.Migrations;

namespace eticaret1.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Productt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryyProductt",
                columns: table => new
                {
                    CategoryysCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProducttsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryyProductt", x => new { x.CategoryysCategoryId, x.ProducttsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Categoryy_CategoryysCategoryId",
                        column: x => x.CategoryysCategoryId,
                        principalTable: "Categoryy",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Productt_ProducttsProductId",
                        column: x => x.ProducttsProductId,
                        principalTable: "Productt",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_ProducttsProductId",
                table: "CategoryyProductt",
                column: "ProducttsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryyProductt");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Productt");
        }
    }
}
