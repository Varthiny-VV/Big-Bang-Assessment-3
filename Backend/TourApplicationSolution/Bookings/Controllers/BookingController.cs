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

    public class BookingController : ControllerBase
    {
        private readonly IRepo<Booking, int> _reservationRepo;
        private readonly IManageBooking _bookingService;

        public BookingController(IRepo<Booking, int> reservationRepo, IManageBooking bookingService)
        {
            _reservationRepo = reservationRepo;
            _bookingService = bookingService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<Booking?>> AddReservation(Booking item)
        {
            try
            {
                var reservation = await _bookingService.AddReseration(item);
                if (reservation != null)
                {
                    return Created("Added :)", reservation);
                }
                return BadRequest("Unable to add");
            }
            catch (Exception)
            {
                return BadRequest("Backend error :(");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Booking>> UpdateReservation(Booking item)
        {
            try
            {
                var res = await _reservationRepo.Update(item);
                if (res != null)
                {
                    return Ok(res);
                }
                return BadRequest("Not updated");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Booking>> GetReservation(int id)
        {
            try
            {
                var resItem = await _reservationRepo.Get(id);
                if (resItem != null)
                {
                    return Ok(resItem);
                }
                return BadRequest("No reservations found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Booking>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationRepo.GetAll();
                if (reservations != null)
                {
                    return Ok(reservations);
                }
                return BadRequest("No reservations available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Booking>>> GetReservationsByTraveller(string id)
        {
            try
            {
                var resItem = await _bookingService.GetReservationByTravellerEmail(id);
                if (resItem != null)
                {
                    return Ok(resItem);
                }
                return BadRequest("No tour available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }
    }
}
