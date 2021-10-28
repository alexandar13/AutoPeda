using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class PotkategorijaProizvoda
    {
        [Key]
        [MaxLength(40)]
        public string Naziv { get; set; }

        public KategorijaProizvoda Kategorija { get; set; }
        public string KategorijaNaziv { get; set; }
    }
}