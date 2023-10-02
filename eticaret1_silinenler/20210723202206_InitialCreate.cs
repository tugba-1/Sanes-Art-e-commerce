using Microsoft.EntityFrameworkCore.Migrations;

namespace eticaret1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryyProductt_Categoryys_CategoryyCategoryId",
                table: "CategoryyProductt");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryyProductt_Productt_ProducttProductId",
                table: "CategoryyProductt");

            migrationBuilder.DropIndex(
                name: "IX_CategoryyProductt_CategoryyCategoryId",
                table: "CategoryyProductt");

            migrationBuilder.DropIndex(
                name: "IX_CategoryyProductt_ProducttProductId",
                table: "CategoryyProductt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoryys",
                table: "Categoryys");

            migrationBuilder.DropColumn(
                name: "CategoryyCategoryId",
                table: "CategoryyProductt");

            migrationBuilder.DropColumn(
                name: "ProducttProductId",
                table: "CategoryyProductt");

            migrationBuilder.RenameTable(
                name: "Categoryys",
                newName: "Categoryy");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CategoryyProductt",
                newName: "ProducttsProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryyProductt",
                newName: "CategoryysCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Productt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoryy",
                table: "Categoryy",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_ProducttsProductId",
                table: "CategoryyProductt",
                column: "ProducttsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryyProductt_Categoryy_CategoryysCategoryId",
                table: "CategoryyProductt",
                column: "CategoryysCategoryId",
                principalTable: "Categoryy",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryyProductt_Productt_ProducttsProductId",
                table: "CategoryyProductt",
                column: "ProducttsProductId",
                principalTable: "Productt",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryyProductt_Categoryy_CategoryysCategoryId",
                table: "CategoryyProductt");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryyProductt_Productt_ProducttsProductId",
                table: "CategoryyProductt");

            migrationBuilder.DropIndex(
                name: "IX_CategoryyProductt_ProducttsProductId",
                table: "CategoryyProductt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoryy",
                table: "Categoryy");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Productt");

            migrationBuilder.RenameTable(
                name: "Categoryy",
                newName: "Categoryys");

            migrationBuilder.RenameColumn(
                name: "ProducttsProductId",
                table: "CategoryyProductt",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryysCategoryId",
                table: "CategoryyProductt",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryyCategoryId",
                table: "CategoryyProductt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProducttProductId",
                table: "CategoryyProductt",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoryys",
                table: "Categoryys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_CategoryyCategoryId",
                table: "CategoryyProductt",
                column: "CategoryyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryyProductt_ProducttProductId",
                table: "CategoryyProductt",
                column: "ProducttProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryyProductt_Categoryys_CategoryyCategoryId",
                table: "CategoryyProductt",
                column: "CategoryyCategoryId",
                principalTable: "Categoryys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryyProductt_Productt_ProducttProductId",
                table: "CategoryyProductt",
                column: "ProducttProductId",
                principalTable: "Productt",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
