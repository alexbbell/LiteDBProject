using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteDBProject.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremixVitamins_Premix_VitaminId",
                table: "PremixVitamins");

            migrationBuilder.CreateIndex(
                name: "IX_PremixVitamins_PremixId",
                table: "PremixVitamins",
                column: "PremixId");

            migrationBuilder.AddForeignKey(
                name: "FK_PremixVitamins_Premix_PremixId",
                table: "PremixVitamins",
                column: "PremixId",
                principalTable: "Premix",
                principalColumn: "PremixId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremixVitamins_Premix_PremixId",
                table: "PremixVitamins");

            migrationBuilder.DropIndex(
                name: "IX_PremixVitamins_PremixId",
                table: "PremixVitamins");

            migrationBuilder.AddForeignKey(
                name: "FK_PremixVitamins_Premix_VitaminId",
                table: "PremixVitamins",
                column: "VitaminId",
                principalTable: "Premix",
                principalColumn: "PremixId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
