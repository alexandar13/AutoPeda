using System;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Narudzbina
    {   
        [Key]
        public int Id { get; set; }
        
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }

        [Required]
        public DateTime DatumNarucivanja { get; set; }

        public int Kolicina { get; set; }
        
    }
    
}