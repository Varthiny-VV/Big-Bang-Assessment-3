using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{
    public class AdditionalTravellers
    {
        [Key]
        public int AdditionalTravellerId { get; set; }
        public int? PackageId { get; set; }
        [ForeignKey("id")]
        public Booking? Booking { get; set; }
        public string? TravellerEmail { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
