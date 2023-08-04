using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourPackages.Models
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }

        public string? DayAndDayTitle { get; set; }
        public string? DestinationName { get; set; }
        public string? DestinationDescription { get; set; }
        public PackageImages? PackageImages { get; set; }
    }
}
