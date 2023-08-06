using Feedbacks.Interfaces;
using Feedbacks.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks.Services
{
    public class FeedbackServices : IRepo<Feedback>
    {
        private readonly Context _context;
        private readonly ILogger<FeedbackServices> _logger;

        public FeedbackServices(Context context, ILogger<FeedbackServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Feedback?> Add(Feedback item)
        {
            try
            {
                var addedItem = await _context.Feedbacks.AddAsync(item);
                await _context.SaveChangesAsync();
                return addedItem.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding feedback.");
                return null;
            }
        }

        public async Task<ICollection<Feedback>?> GetAll()
        {
            try
            {
                return await _context.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedbacks.");
                return null;
            }
        }
    }
}