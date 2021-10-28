using AutoPeda.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPeda.Data
{
    public class AutoPedaContext : DbContext
    {
        public AutoPedaContext(DbContextOptions<AutoPedaContext> opt) : base(opt)
        {
            
        }

        public DbSet<Auto> Automobili {get; set;}
        
        public DbSet<Korisnik> Korisnici {get; set;}

        public DbSet<Marka> Marke {get; set;}

        public DbSet<Model> Modeli {get; set;}

         public DbSet<Motor> Motori {get; set;}

         public DbSet<Narudzbina> Narudzbine {get; set;}

        public DbSet<Proizvod> Proizvodi {get; set;}

        public DbSet<AutoMotor> AutoMotor {get; set;}
        
        public DbSet<Slika> Slike {get; set;}

        public DbSet<KategorijaProizvoda> Kategorije {get; set;}

        public DbSet<PotkategorijaProizvoda> Potkategorije {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AutoMotor>()
                .HasKey(am => new {am.AutoId, am.MotorId});

            builder.Entity<Narudzbina>()
                .HasOne(n => n.Korisnik)
                .WithMany(n => n.Narudzbine)
                .HasForeignKey(n => n.KorisnikId);

            builder.Entity<Narudzbina>()
                .HasOne(n => n.Proizvod)
                .WithMany(n => n.Narudzbine)
                .HasForeignKey(n => n.ProizvodId);

            
        }
    }
}