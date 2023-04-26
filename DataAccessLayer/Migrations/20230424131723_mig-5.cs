using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MesajSahibiSoyisim",
                table: "IletisimForm",
                newName: "MesajSahibiTelefon");

            migrationBuilder.RenameColumn(
                name: "MesajSahibiIsim",
                table: "IletisimForm",
                newName: "MesajSahibiIsimSoyisim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MesajSahibiTelefon",
                table: "IletisimForm",
                newName: "MesajSahibiSoyisim");

            migrationBuilder.RenameColumn(
                name: "MesajSahibiIsimSoyisim",
                table: "IletisimForm",
                newName: "MesajSahibiIsim");
        }
    }
}
