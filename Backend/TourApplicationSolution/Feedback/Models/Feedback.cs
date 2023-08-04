using System.ComponentModel.DataAnnotations;

namespace Feedbacks.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public int? TravellerID { get; set; }
        public int? TourPackageId { get; set; }
        public string? Comment { get; set; }
        public int? AgencyId { get; set; }
        public int? Ratings { get; set; }
        public DateTime? FeedbackDate { get; set; }
    }
}
