using Feedbacks.Interfaces;
using Feedbacks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IRepo<Feedback> _feedbackRepo;
        private readonly ILogger<FeedBackController> _logger;

        public FeedBackController(IRepo<Feedback> feedbackRepo, ILogger<FeedBackController> logger)
        {
            _feedbackRepo = feedbackRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(Feedback feedback)
        {
            try
            {
                var addedFeedback = await _feedbackRepo.Add(feedback);
                if (addedFeedback != null)
                {
                    return Ok(addedFeedback);
                }
                else
                {
                    return BadRequest("Failed to add feedback.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding feedback.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Feedback>>> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await _feedbackRepo.GetAll();
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                else
                {
                    return NotFound("No feedbacks found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving feedbacks.");
                return StatusCode(500, "Internal Server Error");
            }
        }




    }
}
