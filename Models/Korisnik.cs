using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prezime { get; set; }

        [Required]
        [MaxLength(30)]
        public string Sifra { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefon { get; set; }
        
        public ICollection<Narudzbina> Narudzbine  { get; set; }
    }
}