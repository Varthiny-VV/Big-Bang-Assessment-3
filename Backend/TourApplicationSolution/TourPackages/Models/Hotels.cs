using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackages.Models
{
    public class Hotels
    {
        [Key]
        public int HotelId { get; set; }
        [ForeignKey("ItineraryId")]
        public int ItineraryId { get; set; }
        public Itinerary itinerary { get; set; }
        [Required]
        public string? HotelName { get; set;}
        public int HotelRatings { get; set; }
        [Required]
        public string? RoomType { get; set; }
        [Required]
        public string? Breakfast { get; set; }
        
    }
}
