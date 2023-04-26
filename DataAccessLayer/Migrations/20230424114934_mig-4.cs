using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MesajSahibiIsim",
                table: "IletisimForm",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MesajSahibiMail",
                table: "IletisimForm",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MesajSahibiSoyisim",
                table: "IletisimForm",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TextMesaj",
                table: "IletisimForm",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesajSahibiIsim",
                table: "IletisimForm");

            migrationBuilder.DropColumn(
                name: "MesajSahibiMail",
                table: "IletisimForm");

            migrationBuilder.DropColumn(
                name: "MesajSahibiSoyisim",
                table: "IletisimForm");

            migrationBuilder.DropColumn(
                name: "TextMesaj",
                table: "IletisimForm");
        }
    }
}
