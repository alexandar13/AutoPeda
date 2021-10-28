﻿// <auto-generated />
using System;
using AutoPeda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoPeda.Migrations
{
    [DbContext(typeof(AutoPedaContext))]
    [Migration("20210412215410_DodataOgranicenjaNaKategorijeFinal")]
    partial class DodataOgranicenjaNaKategorijeFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoPeda.Models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarkaNaziv")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarkaNaziv");

                    b.HasIndex("ModelId");

                    b.ToTable("Automobili");
                });

            modelBuilder.Entity("AutoPeda.Models.AutoMotor", b =>
                {
                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("MotorId")
                        .HasColumnType("int");

                    b.HasKey("AutoId", "MotorId");

                    b.HasIndex("MotorId");

                    b.ToTable("AutoMotor");
                });

            modelBuilder.Entity("AutoPeda.Models.KategorijaProizvoda", b =>
                {
                    b.Property<string>("Naziv")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Naziv");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("AutoPeda.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("AutoPeda.Models.Marka", b =>
                {
                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Naziv");

                    b.ToTable("Marke");
                });

            modelBuilder.Entity("AutoPeda.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GodisteDo")
                        .HasColumnType("int");

                    b.Property<int?>("GodisteOd")
                        .HasColumnType("int");

                    b.Property<string>("MarkaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naziv")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("Modeli");
                });

            modelBuilder.Entity("AutoPeda.Models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kilovati")
                        .HasColumnType("int");

                    b.Property<int>("Kubikaza")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motori");
                });

            modelBuilder.Entity("AutoPeda.Models.Narudzbina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumNarucivanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Narudzbine");
                });

            modelBuilder.Entity("AutoPeda.Models.PotkategorijaProizvoda", b =>
                {
                    b.Property<string>("Naziv")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("KategorijaNaziv")
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Naziv");

                    b.HasIndex("KategorijaNaziv");

                    b.ToTable("Potkategorije");
                });

            modelBuilder.Entity("AutoPeda.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("KategorijaNaziv")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<int?>("Popust")
                        .HasColumnType("int");

                    b.Property<string>("PotkategorijaNaziv")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Proizvodjac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stanje")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaNaziv");

                    b.HasIndex("PotkategorijaNaziv");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("AutoPeda.Models.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProizvodId")
                        .HasColumnType("int");

                    b.Property<byte[]>("slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Slike");
                });

            modelBuilder.Entity("AutoPeda.Models.Auto", b =>
                {
                    b.HasOne("AutoPeda.Models.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaNaziv");

                    b.HasOne("AutoPeda.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.Navigation("Marka");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoPeda.Models.AutoMotor", b =>
                {
                    b.HasOne("AutoPeda.Models.Auto", "Auto")
                        .WithMany("Motori")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPeda.Models.Motor", "Motor")
                        .WithMany("Automobili")
                        .HasForeignKey("MotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Motor");
                });

            modelBuilder.Entity("AutoPeda.Models.Model", b =>
                {
                    b.HasOne("AutoPeda.Models.Marka", "Marka")
                        .WithMany("Modeli")
                        .HasForeignKey("MarkaId");

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("AutoPeda.Models.Narudzbina", b =>
                {
                    b.HasOne("AutoPeda.Models.Korisnik", "Korisnik")
                        .WithMany("Narudzbine")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPeda.Models.Proizvod", "Proizvod")
                        .WithMany("Narudzbine")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("AutoPeda.Models.PotkategorijaProizvoda", b =>
                {
                    b.HasOne("AutoPeda.Models.KategorijaProizvoda", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaNaziv");

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("AutoPeda.Models.Proizvod", b =>
                {
                    b.HasOne("AutoPeda.Models.KategorijaProizvoda", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaNaziv");

                    b.HasOne("AutoPeda.Models.PotkategorijaProizvoda", "Potkategorija")
                        .WithMany()
                        .HasForeignKey("PotkategorijaNaziv");

                    b.Navigation("Kategorija");

                    b.Navigation("Potkategorija");
                });

            modelBuilder.Entity("AutoPeda.Models.Slika", b =>
                {
                    b.HasOne("AutoPeda.Models.Proizvod", "Proizvod")
                        .WithMany("Slike")
                        .HasForeignKey("ProizvodId");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("AutoPeda.Models.Auto", b =>
                {
                    b.Navigation("Motori");
                });

            modelBuilder.Entity("AutoPeda.Models.Korisnik", b =>
                {
                    b.Navigation("Narudzbine");
                });

            modelBuilder.Entity("AutoPeda.Models.Marka", b =>
                {
                    b.Navigation("Modeli");
                });

            modelBuilder.Entity("AutoPeda.Models.Motor", b =>
                {
                    b.Navigation("Automobili");
                });

            modelBuilder.Entity("AutoPeda.Models.Proizvod", b =>
                {
                    b.Navigation("Narudzbine");

                    b.Navigation("Slike");
                });
#pragma warning restore 612, 618
        }
    }
}
