using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackages.Models
{
    public class Itinerary
    {
        [Key]
        public int ItineraryId { get; set; }
        [ForeignKey("PackageId")]

        public int PackageId { get; set; }
        public string? PackageName { get; set; }
        public string? DayAndDayTitle { get; set; }
        public string? DestinationName { get; set; }
        public string? DestinationDescription { get; set; }
        public string? FoodDetails { get; set; }            
        public List<PackageImages>? PackageImages { get; set; }
        public List<Hotels>? StayingHotels { get; set; }
    }
}
