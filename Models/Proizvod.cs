using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Proizvod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        public int Cena { get; set; }

        public int? Stanje { get; set; }

        [MaxLength(700)]
        public string Opis { get; set; }
         
        public string Proizvodjac { get; set; }

        public KategorijaProizvoda Kategorija { get; set; }
        public string KategorijaNaziv { get; set; }
        
        public PotkategorijaProizvoda Potkategorija { get; set; }
        public string PotkategorijaNaziv { get; set; }
        
        public int? Popust { get; set; }

        public ICollection<Slika> Slike { get; set; }

        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}