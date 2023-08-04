using System.ComponentModel.DataAnnotations;

namespace TourPackages.Models
{
    public class Package
    {
        public Package()
        {
            PackageName = string.Empty;
            TravelAgencyName = string.Empty;
            Description = string.Empty;
            Duration = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
            Destination = string.Empty;
            Transportation = string.Empty;
           
        }

        [Key]
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string TravelAgencyName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Price { get; set; }
        public string Destination { get; set; }
        public string Transportation { get; set; }
        public int AvailabilityCount { get; set; }
        public ICollection<PackageImages>? Image { get; set; }
        public ICollection<Itinerary>? Itinerary { get; set; }
        public AgentContact? AgentContact { get; set; }
    }
}
