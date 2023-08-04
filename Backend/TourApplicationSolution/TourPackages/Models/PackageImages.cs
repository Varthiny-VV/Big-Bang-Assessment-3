using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourPackages.Models
{
    public class PackageImages
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }

        public string? PackageName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
