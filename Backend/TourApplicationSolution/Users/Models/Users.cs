using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? EmailId { get; set; }
        public string? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
    }
}
