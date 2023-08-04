using Feedbacks.Interfaces;
using Feedbacks.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks.Services
{
    public class FeedbackRepo : IRepo<Feedback, int>
    {
        private readonly Context _context;
        public FeedbackRepo(Context context)
        {
            _context = context;
        }
        public async Task<Feedback?> Add(Feedback item)
        {

            var fb = _context.Feedbacks.SingleOrDefault(f => f.feedbackID == item.feedbackID);
            if (fb == null)
            {
                try
                {
                    _context.Feedbacks.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }

            }
            return null;
        }

        public async Task<Feedback?> Delete(int id)
        {
            try
            {
                var fb = await Get(id);
                if (fb != null)
                {
                    _context.Feedbacks.Remove(fb);
                    await _context.SaveChangesAsync();
                    return fb;
                }
                return null;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Feedback?> Get(int id)
        {
            try
            {
                var user = await _context.Feedbacks.SingleOrDefaultAsync(f => f.feedbackID == id);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Feedback>?> GetAll()
        {
            try
            {
                var fb = await _context.Feedbacks.ToListAsync();
                if (fb != null)
                {
                    return fb;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Feedback?> Update(Feedback item)
        {
            var fb = _context.Feedbacks.SingleOrDefault(f => f.feedbackID == item.feedbackID);
            if (fb != null)
            {
                try
                {
                    fb.travellerID = item.TravellerID;
                    fb.FeedbackDate = item.FeedbackDate;
                    fb.TourPackageId = item.TourPackageId;
                    fb.Ratings = item.Ratings;
                    fb.Comment = item.Comment;
                    await _context.SaveChangesAsync();
                    return fb;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}
