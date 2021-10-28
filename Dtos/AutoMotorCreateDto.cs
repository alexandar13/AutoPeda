using AutoPeda.Models;

namespace AutoPeda.Dtos
{
    public class AutoMotorCreateDto
    {
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public int MotorId { get; set; }
        public Motor Motor { get; set; }
    }
}