using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class MotorUpdateDto
    {
        [Required]
        public int Kubikaza { get; set; }

        [Required]
        public string Tip { get; set; }

        public int Kilovati { get; set; }

    }
}