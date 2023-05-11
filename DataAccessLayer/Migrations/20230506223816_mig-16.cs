using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "UrunCesitId",
            //    table: "Markalar",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Markalar_UrunCesitId",
            //    table: "Markalar",
            //    column: "UrunCesitId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Markalar_UrunCesitleri_UrunCesitId",
            //    table: "Markalar",
            //    column: "UrunCesitId",
            //    principalTable: "UrunCesitleri",
            //    principalColumn: "UrunCesitId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markalar_UrunCesitleri_UrunCesitId",
                table: "Markalar");

            migrationBuilder.DropIndex(
                name: "IX_Markalar_UrunCesitId",
                table: "Markalar");

            migrationBuilder.DropColumn(
                name: "UrunCesitId",
                table: "Markalar");
        }
    }
}
