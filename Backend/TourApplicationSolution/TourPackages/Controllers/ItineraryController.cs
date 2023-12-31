﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourPackages.Interfaces;
using TourPackages.Models;


namespace TourPackages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class ItineraryController : ControllerBase
    {
        private readonly IRepo<int, Itinerary> _itineraryRepo;

        public ItineraryController(IRepo<int, Itinerary> itineraryRepo)
        {
            _itineraryRepo = itineraryRepo;
        }
        [HttpPost]
        public async Task<ActionResult<Itinerary>> AddItinerary(Itinerary itinerary)
        {
            var addedItinerary = await _itineraryRepo.Add(itinerary);
            if (addedItinerary != null)
            {
                return Ok(addedItinerary);
            }
            return BadRequest("Failed to add itinerary.");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Itinerary>> UpdateItinerary(int id, Itinerary itinerary)
        {
            if (id != itinerary.Id)
            {
                return BadRequest("Itinerary ID mismatch.");
            }

            var updatedItinerary = await _itineraryRepo.Update(itinerary);
            if (updatedItinerary != null)
            {
                return Ok(updatedItinerary);
            }
            return NotFound("Itinerary not found.");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Itinerary>> DeleteItinerary(int id)
        {
            var deletedItinerary = await _itineraryRepo.Delete(id);
            if (deletedItinerary != null)
            {
                return Ok(deletedItinerary);
            }
            return NotFound("Itinerary not found.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerary>> GetItinerary(int id)
        {
            var itinerary = await _itineraryRepo.Get(id);
            if (itinerary != null)
            {
                return Ok(itinerary);
            }
            return NotFound("Itinerary not found.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerary>>> GetAllItineraries()
        {
            var itineraries = await _itineraryRepo.GetAll();
            if (itineraries != null && itineraries.Count > 0)
            {
                return Ok(itineraries);
            }
            return NotFound("No itineraries found.");
        }
    }
}
