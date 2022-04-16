using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LandmarksController : ControllerBase
    {
        private readonly ILandmarksDao landmarksDao;
        public LandmarksController(ILandmarksDao landmarksDao)
        {
            this.landmarksDao = landmarksDao;
        }
        [HttpGet]
        public ActionResult<List<Landmark>> GetLandmarks()
        {
            List<Landmark> landmarks = landmarksDao.GetLandmarks();
            return Ok(landmarks);
        }

        [HttpPost]
        public ActionResult<Landmark> AddLandmark(Landmark landmark)
        {
            Landmark result = landmarksDao.AddLandmark(landmark);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("{landmarkId}")]
        public ActionResult<Landmark> GetLandmark(int landmarkId) 
        {
            Landmark landmark = landmarksDao.GetLandmark(landmarkId);
            if (landmark == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(landmark);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateLandmark(int itenAdd, int landmarkId)
        {
            bool result = landmarksDao.UpdateLandmark(itenAdd, landmarkId);
            if (result == true)
            {
                return Ok("Landmark updated");
            }
            else
            {
                return BadRequest("There was a problem updating your Landmark.");
            }
        }
    }
    
}
