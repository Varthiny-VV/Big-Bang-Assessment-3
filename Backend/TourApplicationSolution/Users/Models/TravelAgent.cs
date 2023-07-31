using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class TravelAgent
    {
        public TravelAgent()
        {
            Name = string.Empty;
        }
        [Key]
        public int TravelAgentId { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? AgencyName { get; set; }
        public string? GSTNumber { get; set; }
        public string? IsApproved { get; set; }
        public Users? Users { get; set; }
    }
}
