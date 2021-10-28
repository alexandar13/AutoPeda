using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPeda.Migrations
{
    public partial class DodatoJosNesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KategorijaNaziv",
                table: "Potkategorije",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Potkategorije_KategorijaNaziv",
                table: "Potkategorije",
                column: "KategorijaNaziv");

            migrationBuilder.AddForeignKey(
                name: "FK_Potkategorije_Kategorije_KategorijaNaziv",
                table: "Potkategorije",
                column: "KategorijaNaziv",
                principalTable: "Kategorije",
                principalColumn: "Naziv",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Potkategorije_Kategorije_KategorijaNaziv",
                table: "Potkategorije");

            migrationBuilder.DropIndex(
                name: "IX_Potkategorije_KategorijaNaziv",
                table: "Potkategorije");

            migrationBuilder.DropColumn(
                name: "KategorijaNaziv",
                table: "Potkategorije");
        }
    }
}
