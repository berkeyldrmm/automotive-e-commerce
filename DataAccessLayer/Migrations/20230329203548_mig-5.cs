using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Kullanicilar",
                newName: "Siparisler");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Kullanicilar",
                newName: "Sifre");

            migrationBuilder.RenameColumn(
                name: "Orders",
                table: "Kullanicilar",
                newName: "Kullaniciadi");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Kullanicilar",
                newName: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Siparisler",
                table: "Kullanicilar",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Sifre",
                table: "Kullanicilar",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Kullaniciadi",
                table: "Kullanicilar",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Kullanicilar",
                newName: "UserId");
        }
    }
}
