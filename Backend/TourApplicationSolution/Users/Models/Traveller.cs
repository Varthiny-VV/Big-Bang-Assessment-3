using System.ComponentModel.DataAnnotations;

namespace SignInAndSignUp.Models
{
    public class Traveller
    {
        public Traveller()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }
        [Key]
        public int TravellerId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Address { get; set; }

        public Users? Users { get; set; }
    }
}
