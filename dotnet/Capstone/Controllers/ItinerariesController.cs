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

        //GET ALL USER'S ITINERARIES
        [HttpGet("fetchuser/{userId}")]
        public IActionResult GetUserItineraries(int userId)
        {
            List<Itinerary> result = itineraryDAO.RetrieveUserItineraries(userId);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }

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

        //REMOVE A LANDMARK FROM ITINERARY
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

        //GET ITINERARY AND ALL LANDMARKS ON IT
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

        //ADDS LANDMARK TO AN ITINERARY
        //[HttpPost("addlandmark")]
        // public IActionResult AddLandmarkToItinerary(ItineraryDetails i)
        // {
        //     bool result = itineraryDAO.AddLandmarkToItinerary(i);
        //     if (result == true)
        //     {
        //         return Ok("Landmarkd added to itenerary successfully");
        //     }
        //     else
        //     {
        //         return BadRequest("There was a problem adding that to your itinerary.");
        //     }
        // } 

        //GET/SET CURRENT ITINERARY
        [HttpGet("fetch/{itineraryId}")]
        public IActionResult GetSetItinerary(int itineraryId)
        {
            Itinerary result = itineraryDAO.GetItinerary(itineraryId);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }

        }

        //GETS ALL ITINERARIES IN DATABASE
        [HttpGet("fetch")]
        public ActionResult<Itinerary> GetItineraries()
        {
            List<Itinerary> itineraries = itineraryDAO.GetItineraries();

            return Ok(itineraries);

        }
        [HttpPost("addlandmark/{itineraryId}/{landmarkId}/{userId}")]
        public IActionResult AddLandmarkToItinerary(int itineraryId, int landmarkId, int userId)
        {
            bool result = itineraryDAO.AddLandmarkToItinerary(itineraryId, landmarkId, userId);
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
