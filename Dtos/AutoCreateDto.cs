using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class AutoCreateDto
    {
        public string MarkaNaziv { get; set; }
        public Marka Marka { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
        
    }
}