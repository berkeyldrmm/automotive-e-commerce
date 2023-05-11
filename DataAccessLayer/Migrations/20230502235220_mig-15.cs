using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_UrunCesitleri_UrunCesitId",
                table: "Kategoriler",
                column: "UrunCesitId",
                principalTable: "UrunCesitleri",
                principalColumn: "UrunCesitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_UrunCesitleri_UrunCesitId",
                table: "Kategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Kategoriler_UrunCesitId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "UrunCesitId",
                table: "Kategoriler");
        }
    }
}
