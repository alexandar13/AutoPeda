using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPeda.Migrations
{
    public partial class Privremeno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Potkategorije",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PotkategorijaNaziv",
                table: "Proizvodi",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Potkategorije",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

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
    }
}
