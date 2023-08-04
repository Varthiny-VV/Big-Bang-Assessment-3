using Feedbacks.Models;

namespace Feedbacks.Interfaces
{
    public interface IFeedback
    {
        
            public Task<Feedback?> AddReview(feedback item);
            public Task<Feedback?> DeleteReview(int id);
            public Task<Feedback?> GetReview(int id);
            public Task<ICollection<Feedback>?> GetAllReviews();
        
    }
}
