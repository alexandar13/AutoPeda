using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class AutoUpdateDto
    {
        public string MarkaNaziv { get; set; }
        public Marka Marka { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<AutoMotor> Motori { get; set; }
        
    }
}