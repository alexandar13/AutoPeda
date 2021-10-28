using System.ComponentModel.DataAnnotations;
using System;

namespace AutoPeda.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Naziv { get; set; }

        public string MarkaId { get; set; }
        public Marka Marka { get; set; }
        public int? GodisteOd { get; set; }
        public int? GodisteDo { get; set; }
    }
}