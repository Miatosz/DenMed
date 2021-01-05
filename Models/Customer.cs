using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenMed.Models
{
    public class Customer
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(20)]
        public string Name {get; set;}

        [Required]
        public string Surname { get; set; }
    
        [Required]
        public int Pesel {get; set;}

        [Required]
        [Phone]
        public string PhoneNumber {get; set;}

        [ForeignKey("Address")]
        public int AdressId {get; set;}
        public Address Adress { get; set; }

        public ICollection<Reservation> Reservations {get; set;}
    }
}