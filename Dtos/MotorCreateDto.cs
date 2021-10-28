using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class MotorCreateDto
    {
        [Required]
        public int Kubikaza { get; set; }

        [Required]
        public string Tip { get; set; }

        public int Kilovati { get; set; }
    }
}