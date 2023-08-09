using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourPackages.Interfaces;
using TourPackages.Models;


namespace TourPackages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class AgentContactController : ControllerBase
    {
        private readonly IRepo<int, AgentContact> _contactDetailsRepo;

        public AgentContactController(IRepo<int, AgentContact> contactDetailsRepo)
        {
            _contactDetailsRepo = contactDetailsRepo;

        }
        [HttpPost]
        public async Task<ActionResult<AgentContact>> AddContactDetails(AgentContact contactDetails)
        {
            var result = await _contactDetailsRepo.Add(contactDetails);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to add contact details.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgentContact>> UpdateContactDetails(int id, AgentContact contactDetails)
        {
            if (id != contactDetails.Id)
            {
                return BadRequest("ContactDetails ID mismatch.");
            }

            var result = await _contactDetailsRepo.Update(contactDetails);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("ContactDetails not found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AgentContact>> DeleteContactDetails(int id)
        {
            var result = await _contactDetailsRepo.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("ContactDetails not found.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgentContact>> GetContactDetails(int id)
        {
            var result = await _contactDetailsRepo.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("ContactDetails not found.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgentContact>>> GetAllContactDetails()
        {
            var result = await _contactDetailsRepo.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No contact details found.");
        }
    }
}
