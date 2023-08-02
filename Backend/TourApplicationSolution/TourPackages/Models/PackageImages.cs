using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackages.Models
{
    public class PackageImages
    {
        public int ImageId { get; set; }
        public string PackageId { get; set; }
        [ForeignKey ("PackageId")]
        public string PackageName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
