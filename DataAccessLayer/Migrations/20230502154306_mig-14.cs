using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "UrunCesidiUrunCesitId",
                table: "Urunler",
                newName: "UrunCesitId");

            migrationBuilder.RenameIndex(
                name: "IX_Urunler_UrunCesidiUrunCesitId",
                table: "Urunler",
                newName: "IX_Urunler_UrunCesitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunCesitleri_UrunCesitId",
                table: "Urunler",
                column: "UrunCesitId",
                principalTable: "UrunCesitleri",
                principalColumn: "UrunCesitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunCesitleri_UrunCesitId",
                table: "Urunler");

            migrationBuilder.RenameColumn(
                name: "UrunCesitId",
                table: "Urunler",
                newName: "UrunCesidiUrunCesitId");

            migrationBuilder.RenameIndex(
                name: "IX_Urunler_UrunCesitId",
                table: "Urunler",
                newName: "IX_Urunler_UrunCesidiUrunCesitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunCesitleri_UrunCesidiUrunCesitId",
                table: "Urunler",
                column: "UrunCesidiUrunCesitId",
                principalTable: "UrunCesitleri",
                principalColumn: "UrunCesitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
