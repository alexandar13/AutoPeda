using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        public string MarkaNaziv { get; set; }
        public Marka Marka { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<AutoMotor> Motori { get; set; }
        
    }
}