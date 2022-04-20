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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewDao reviewDAO;

        public ReviewsController(IReviewDao _reviewDAO)
        {
            reviewDAO = _reviewDAO;
        }

        [HttpGet("{landmarkId}")]
        public IActionResult GetReviews(int landmarkId)
        {
            List<Review> result = reviewDAO.GetReviews(landmarkId);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error - " + ex.Message });
            }

        }

        //CREATE A NEW ITINERARY
        [HttpPost("new-review")]
        public ActionResult<Review> AddReview(Review review)
        {
            Review result = reviewDAO.AddReview(review);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}
