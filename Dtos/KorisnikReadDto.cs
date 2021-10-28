using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class KorisnikReadDto
    {

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Sifra { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }
    }
}