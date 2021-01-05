using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenMed.Models
{
    public class Surgery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public ICollection<Reservation> Reservations {get; set;}
    }
}