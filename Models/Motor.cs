using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPeda.Models
{
    public class Motor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Kubikaza { get; set; }

        [Required]
        public string Tip { get; set; }

        public int Kilovati { get; set; }

        public ICollection<AutoMotor> Automobili { get; set; }
    }
}