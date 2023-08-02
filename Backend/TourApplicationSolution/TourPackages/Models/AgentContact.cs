using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackages.Models
{
    public class AgentContact
    {
        [Key]
        public int ContactId { get; set; }
        [ForeignKey("PackageId")]
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public string? AgentName { get; set; }
        public string? AgentPhoneNumber { get; set;}
        public string? AgentEmail { get; set;}
    }
}
