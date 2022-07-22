using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteDBProject.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "Vitamin",
                columns: table => new
                {
                    VitaminId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Rastvor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitamin", x => x.VitaminId);
                });

            migrationBuilder.CreateTable(
                name: "Premix",
                columns: table => new
                {
                    PremixId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Vid = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<string>(type: "TEXT", nullable: false),
                    Tu = table.Column<string>(type: "TEXT", nullable: false),
                    DeveloperId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premix", x => x.PremixId);
                    table.ForeignKey(
                        name: "FK_Premix_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremixVitamins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PremixId = table.Column<int>(type: "INTEGER", nullable: false),
                    VitaminId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremixVitamins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremixVitamins_Premix_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Premix",
                        principalColumn: "PremixId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PremixVitamins_Vitamin_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Vitamin",
                        principalColumn: "VitaminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "DeveloperId", "Country", "Name" },
                values: new object[] { 1, "England", "Terezia" });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "DeveloperId", "Country", "Name" },
                values: new object[] { 2, "Russia", "Resurs" });

            migrationBuilder.InsertData(
                table: "Vitamin",
                columns: new[] { "VitaminId", "Rastvor", "Title" },
                values: new object[] { 1, "rastvor", "A" });

            migrationBuilder.InsertData(
                table: "Vitamin",
                columns: new[] { "VitaminId", "Rastvor", "Title" },
                values: new object[] { 2, "rastvor", "B" });

            migrationBuilder.InsertData(
                table: "Vitamin",
                columns: new[] { "VitaminId", "Rastvor", "Title" },
                values: new object[] { 3, "rastvor", "C" });

            migrationBuilder.InsertData(
                table: "Premix",
                columns: new[] { "PremixId", "Age", "DeveloperId", "Title", "Tu", "Vid" },
                values: new object[] { 1, "small", 1, "Premix 1", "tu 1", "rastvor" });

            migrationBuilder.CreateIndex(
                name: "IX_Premix_DeveloperId",
                table: "Premix",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_PremixVitamins_VitaminId",
                table: "PremixVitamins",
                column: "VitaminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PremixVitamins");

            migrationBuilder.DropTable(
                name: "Premix");

            migrationBuilder.DropTable(
                name: "Vitamin");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
