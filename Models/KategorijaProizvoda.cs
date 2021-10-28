using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class KategorijaProizvoda
    {
        [Key]
        [MaxLength(25)]
        public string Naziv { get; set; }
    }
}