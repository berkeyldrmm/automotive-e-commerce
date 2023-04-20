using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrun_Siparisler_SiparisId",
                table: "SiparisUrun");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrun_Urunler_UrunId",
                table: "SiparisUrun");

            migrationBuilder.RenameColumn(
                name: "UrunId",
                table: "SiparisUrun",
                newName: "UrunlerUrunId");

            migrationBuilder.RenameColumn(
                name: "SiparisId",
                table: "SiparisUrun",
                newName: "SiparislerSiparisId");

            migrationBuilder.RenameIndex(
                name: "IX_SiparisUrun_UrunId",
                table: "SiparisUrun",
                newName: "IX_SiparisUrun_UrunlerUrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrun_Siparisler_SiparislerSiparisId",
                table: "SiparisUrun",
                column: "SiparislerSiparisId",
                principalTable: "Siparisler",
                principalColumn: "SiparisId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrun_Urunler_UrunlerUrunId",
                table: "SiparisUrun",
                column: "UrunlerUrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrun_Siparisler_SiparislerSiparisId",
                table: "SiparisUrun");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrun_Urunler_UrunlerUrunId",
                table: "SiparisUrun");

            migrationBuilder.RenameColumn(
                name: "UrunlerUrunId",
                table: "SiparisUrun",
                newName: "UrunId");

            migrationBuilder.RenameColumn(
                name: "SiparislerSiparisId",
                table: "SiparisUrun",
                newName: "SiparisId");

            migrationBuilder.RenameIndex(
                name: "IX_SiparisUrun_UrunlerUrunId",
                table: "SiparisUrun",
                newName: "IX_SiparisUrun_UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrun_Siparisler_SiparisId",
                table: "SiparisUrun",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "SiparisId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrun_Urunler_UrunId",
                table: "SiparisUrun",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
