using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackages.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        [Required]
        public string? PackageName { get; set; }
        [Required]
        public string? TravelAgencyName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Duration { get; set; }
        [Required]
        public string? StartDate { get; set; }
        [Required]
        public string? EndDate { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Destination { get; set; }
        [Required]
        public string? Transpotation { get; set; }
        public string? NoOfPersons { get; set; }
        [Required]
        public string? AvailabilityCount { get; set; }
        [Required]
        public List<PackageImages>? Image { get; set;}
     
    }
}
