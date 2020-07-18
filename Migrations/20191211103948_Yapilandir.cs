using Microsoft.EntityFrameworkCore.Migrations;

namespace FiratHoca.Migrations
{
    public partial class Yapilandir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebekler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: false),
                    Aciklama = table.Column<string>(nullable: false),
                    Kilo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DosyaAdi = table.Column<string>(nullable: true),
                    BebekuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resimler_Bebekler_BebekuId",
                        column: x => x.BebekuId,
                        principalTable: "Bebekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_BebekuId",
                table: "Resimler",
                column: "BebekuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resimler");

            migrationBuilder.DropTable(
                name: "Bebekler");
        }
    }
}
