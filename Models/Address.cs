using System.ComponentModel.DataAnnotations;

namespace DenMed.Models
{
    public class Address
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string City {get; set;}

        [Required]
        public string PostCode {get; set;}

        [Required]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }     
    }
}