using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Itinerary
    {
        public int ItineraryId { get; set; }
        public int UserId { get; set; }
        public string ItineraryName { get; set; }
     
    }
    public class ItineraryDetails
    {
        public string LandmarkName { get; set; }
        public string LandmarkLat { get; set; }
        public string LandmarkLng { get; set; }
        public string Description { get; set; }
        public string LandmarkImage { get; set; }
        public int LandmarkId { get; set; }
        public int ItineraryId { get; set; }
        public int UserId { get; set; }

    }
}
