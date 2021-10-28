using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class ProizvodUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        public int Cena { get; set; }

        public int? Stanje { get; set; }

        [MaxLength(700)]
        public string Opis { get; set; }
         
        public string Proizvodjac { get; set; }

        public string Kategorija { get; set; }
        
        public string Tip { get; set; }
        
        public int? Popust { get; set; }

        public ICollection<Slika> Slike { get; set; }

        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}