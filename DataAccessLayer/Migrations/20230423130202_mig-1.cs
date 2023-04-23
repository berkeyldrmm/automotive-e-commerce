using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Siparisler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_StatusId",
                table: "Siparisler",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Status_StatusId",
                table: "Siparisler",
                column: "StatusId",
                principalTable: "StatusList",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Status_StatusId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_StatusId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Siparisler");
        }
    }
}
