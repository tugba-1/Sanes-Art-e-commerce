using Microsoft.EntityFrameworkCore.Migrations;

namespace eticaret1.Migrations
{
    public partial class OnetoManyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productt",
                table: "Productt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoryy",
                table: "Categoryy");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Productt");

            migrationBuilder.RenameTable(
                name: "Productt",
                newName: "Productts");

            migrationBuilder.RenameTable(
                name: "Categoryy",
                newName: "Categoryys");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Categoryys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productts",
                table: "Productts",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoryys",
                table: "Categoryys",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "CategoryyProductt",
                columns: table => new
                {
                    CategoryysCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProducttProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryyProductt", x => new { x.CategoryysCategoryId, x.ProducttProductId });
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Categoryys_CategoryysCategoryId",
                        column: x => x.CategoryysCategoryId,
                        principalTable: "Categoryys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryyProductt_Productts_ProducttProductId",
                        column: x => x.ProducttProductId,
                        principalTable: "Productts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_ProducttProductId",
                table: "CategoryyProductt",
                column: "ProducttProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryyProductt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productts",
                table: "Productts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoryys",
                table: "Categoryys");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categoryys");

            migrationBuilder.RenameTable(
                name: "Productts",
                newName: "Productt");

            migrationBuilder.RenameTable(
                name: "Categoryys",
                newName: "Categoryy");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Productt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productt",
                table: "Productt",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoryy",
                table: "Categoryy",
                column: "CategoryId");
        }
    }
}
