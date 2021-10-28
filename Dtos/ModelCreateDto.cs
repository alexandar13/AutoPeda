using System.ComponentModel.DataAnnotations;
using System;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class ModelCreateDto
    {
        [MaxLength(30)]
        public string Naziv { get; set; }
        public int? GodisteOd { get; set; }
        public int? GodisteDo { get; set; }
    }
}