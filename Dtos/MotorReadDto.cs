using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class MotorReadDto
    {
        public int Kubikaza { get; set; }

        public string Tip { get; set; }

        public int Kilovati { get; set; }
    }
}