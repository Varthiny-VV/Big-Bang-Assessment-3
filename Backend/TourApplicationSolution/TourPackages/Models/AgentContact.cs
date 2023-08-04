using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourPackages.Models
{
    public class AgentContact
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }
        public string? AgentName { get; set; }
        public string? AgentPhoneNumber { get; set; }
        public string? AgentEmail { get; set; }
    }
}
