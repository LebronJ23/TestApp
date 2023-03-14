using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
    public class AppleEater
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int AppleAmount { get; set; } = 1;

        public DateTime Time { get; set; } = DateTime.Now;
    }
}
