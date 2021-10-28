using System;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class NarudzbinaCreateDto
    {           
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }

        [Required]
        public DateTime DatumNarucivanja { get; set; }

        public int Kolicina { get; set; }
        
    }
    
}