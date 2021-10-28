using System.ComponentModel.DataAnnotations;
using System;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class ModelUpdateDto
    {
        [MaxLength(30)]
        public string Naziv { get; set; }

        public string MarkaId { get; set; }
        public Marka Marka { get; set; }
        public int? GodisteOd { get; set; }
        public int? GodisteDo { get; set; }
    }
}