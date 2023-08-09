using Bookings.Interfaces;
using Bookings.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    [Route("api/[controller] /[Action]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class AdditionalController : ControllerBase
    {
        private readonly IRepo<AdditionalTravellers, int> _travellerRepo;
        private readonly IManageBooking _manageService;

        public AdditionalController(IRepo<AdditionalTravellers, int> travellerRepo, IManageBooking manageService)
        {
            _travellerRepo = travellerRepo;
            _manageService = manageService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(AdditionalTravellers), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<AdditionalTravellers?>> Addpassenger(AdditionalTravellers item)
        {
            try
            {
                var passenger = await _travellerRepo.Add(item);
                if (passenger != null)
                {
                    return Created("Added!", passenger);
                }
                return BadRequest("Unable to add");
            }
            catch (Exception)
            {
                return BadRequest("Backend error :(");
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<AdditionalTravellers>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<AdditionalTravellers>>> GetAllPassengers()
        {
            try
            {
                var passenger = await _travellerRepo.GetAll();
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No extra travellers available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(AdditionalTravellers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AdditionalTravellers>> GetPassenger(int id)
        {
            try
            {
                var passenger = await _travellerRepo.Get(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No passenger found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(AdditionalTravellers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AdditionalTravellers>> DeletePassenger(int id)
        {
            try
            {
                var passenger = await _travellerRepo.Delete(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("Not deleted");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(AdditionalTravellers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AdditionalTravellers>> UpdatePassengers(AdditionalTravellers item)
        {
            try
            {
                var passenger = await _travellerRepo.Update(item);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("Not updated");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdditionalTravellers>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<AdditionalTravellers>>> GetGuestsbyTraveller(string id)
        {
            try
            {
                var passenger = await _manageService.GetGuestsByTravellerEmail(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No passengers available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

    }
}
