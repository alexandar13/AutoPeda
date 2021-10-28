using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPeda.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marke",
                columns: table => new
                {
                    Naziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marke", x => x.Naziv);
                });

            migrationBuilder.CreateTable(
                name: "Motori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kubikaza = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilovati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Stanje = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    Proizvodjac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popust = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MarkaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GodisteOd = table.Column<int>(type: "int", nullable: true),
                    GodisteDo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modeli_Marke_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marke",
                        principalColumn: "Naziv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    DatumNarucivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProizvodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slike_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaNaziv = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobili_Marke_MarkaNaziv",
                        column: x => x.MarkaNaziv,
                        principalTable: "Marke",
                        principalColumn: "Naziv",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Automobili_Modeli_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Modeli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoMotor",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    MotorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMotor", x => new { x.AutoId, x.MotorId });
                    table.ForeignKey(
                        name: "FK_AutoMotor_Automobili_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Automobili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMotor_Motori_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Motori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_MarkaNaziv",
                table: "Automobili",
                column: "MarkaNaziv");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_ModelId",
                table: "Automobili",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMotor_MotorId",
                table: "AutoMotor",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeli_MarkaId",
                table: "Modeli",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_KorisnikId",
                table: "Narudzbine",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_ProizvodId",
                table: "Narudzbine",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ProizvodId",
                table: "Slike",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoMotor");

            migrationBuilder.DropTable(
                name: "Narudzbine");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Automobili");

            migrationBuilder.DropTable(
                name: "Motori");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Modeli");

            migrationBuilder.DropTable(
                name: "Marke");
        }
    }
}
