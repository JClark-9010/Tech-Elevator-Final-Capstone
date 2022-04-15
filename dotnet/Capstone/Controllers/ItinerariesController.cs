using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryDAO itineraryDAO;

        public ItineraryController(IItineraryDAO _itineraryDAO)
        {
            itineraryDAO = _itineraryDAO;
        }

        //CREATE A NEW ITINERARY
        [HttpPost("add")]
        public IActionResult AddItinerary(Itinerary itinerary)
        {
            bool result = itineraryDAO.AddItinerary(itinerary);
            if (result == true)
            {
                return Ok("Itinerary added successfully");
            }
            else
            {
                return BadRequest("There was a problem adding that to your itinerary.");
            }
        }


        //DELETE ENTIRE ITINERARY
        [HttpDelete("delete/{itineraryId}")]
        public IActionResult DeleteItinerary(int itineraryId)
        {
            bool result = itineraryDAO.DeleteItinerary(itineraryId);
            if (result == true)
            {
                return Ok("Itinerary deleted successfully");
            }
            else
            {
                return BadRequest("There was a problem deleting that from your itinerary.");
            }
        }

        [HttpDelete("deletelandmark")]
        public IActionResult DeleteLandmarkFromItinerary(ItineraryDetails i)
        {
            bool result = itineraryDAO.DeleteLandmarkFromItinerary(i);
            if (result == true)
            {
                return Ok("Itinerary edited successfully");
            }
            else
            {
                return BadRequest("There was a problem in changing your itinerary.");
            }
        }


        //GET ITINERARY
        [HttpGet("fetch/{id}")]
        public IActionResult GetItineraries(int id)
        {
            List<Itinerary> result = itineraryDAO.RetrieveItineraries(id);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }

        }


        //GET ITINERARY DETAILS (LANDMARK DATA)
        [HttpGet("fetch/details/{itineraryId}")]
        public IActionResult ItineraryDetails(int itineraryId)
        {
            List<ItineraryDetails> result = itineraryDAO.GetItineraryDetails(itineraryId);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }

        }

        [HttpPost("addlandmark")]
        public IActionResult AddLandmarkToItinerary(ItineraryDetails i)
        {
            bool result = itineraryDAO.AddLandmarkToItinerary(i);
            if (result == true)
            {
                return Ok("Landmarkd added to itenerary successfully");
            }
            else
            {
                return BadRequest("There was a problem adding that to your itinerary.");
            }
        }
    }
}
