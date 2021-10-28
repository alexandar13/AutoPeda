using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPeda.Migrations
{
    public partial class PotkategorijeDodatoOgranicenjeMax40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PotkategorijaNaziv",
                table: "Proizvodi",
                type: "nvarchar(40)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_PotkategorijaNaziv",
                table: "Proizvodi",
                column: "PotkategorijaNaziv");

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
                name: "FK_Proizvodi_Potkategorije_PotkategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_PotkategorijaNaziv",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "PotkategorijaNaziv",
                table: "Proizvodi");
        }
    }
}
