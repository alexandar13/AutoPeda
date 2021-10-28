using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Slika
    {
        [Key]
        public int Id { get; set; }

        public byte[] slika { get; set; }
        public int? ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
    }
}