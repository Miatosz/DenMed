using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenMed.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Surgery")]
        public int SurgeryId { get; set; }
        public Surgery Surgery { get; set; }

        
        public string Data { get; set; }
    }
}