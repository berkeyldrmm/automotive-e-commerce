using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Aciklama",
            //    table: "Urunler",
            //    type: "longtext",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "longtext")
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Markalar_MarkaId",
                table: "Urunler",
                column: "MarkaId",
                principalTable: "Markalar",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Aciklama",
                keyValue: null,
                column: "Aciklama",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Urunler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
