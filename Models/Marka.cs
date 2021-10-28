using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Marka
    {
        [Key]
        public string Naziv { get; set; }

        public ICollection<Model> Modeli { get; set; }
    }
}