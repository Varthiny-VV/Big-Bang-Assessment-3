using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int PackageId { get; set; }
        public int? TravelAgentId { get; set; }
        public string? Type { get; set; }
        public int? AvailableCount { get; set; }
        public string? TravellerEmail { get; set; }
        public int TravellerCount { get; set; }
        public ICollection<AdditionalTravellers>? Travellers { get; set; }
        public string? PickUp { get; set; }
        public string? Drop { get; set; }
    }
}
