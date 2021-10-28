using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class ProizvodReadDto
    {

        public string Naziv { get; set; }

        public int Cena { get; set; }

        public int? Stanje { get; set; }

        public string Opis { get; set; }
         
        public string Proizvodjac { get; set; }
        
        public int? Popust { get; set; }

        public ICollection<Slika> Slike { get; set; }
    }
}