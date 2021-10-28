using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPeda.Migrations
{
    public partial class DodateKategorije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategorija",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Proizvodi");

            migrationBuilder.AddColumn<string>(
                name: "KategorijaNaziv",
                table: "Proizvodi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PotkategorijaNaziv",
                table: "Proizvodi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Naziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Naziv);
                });

            migrationBuilder.CreateTable(
                name: "Potkategorije",
                columns: table => new
                {
                    Naziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potkategorije", x => x.Naziv);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_KategorijaNaziv",
                table: "Proizvodi",
                column: "KategorijaNaziv");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_PotkategorijaNaziv",
                table: "Proizvodi",
                column: "PotkategorijaNaziv");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaNaziv",
                table: "Proizvodi",
                column: "KategorijaNaziv",
                principalTable: "Kategorije",
                principalColumn: "Naziv",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Potkategorije_PotkategorijaNaziv",
                table: "Proizvodi",
                column: "PotkategorijaNaziv",
                principalTable: "Potkategorije",
                principalColumn: "Naziv",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Potkategorije_PotkategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Potkategorije");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_KategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_PotkategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "KategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "PotkategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.AddColumn<string>(
                name: "Kategorija",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
