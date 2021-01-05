using System.ComponentModel.DataAnnotations;

namespace DenMed.Models
{
    public class Specialist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname {get; set;}

        [Required]
        public int Age { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}