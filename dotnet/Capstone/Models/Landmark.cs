using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Landmark
    {
        public int LandmarkId { get; set; }
        public string LandmarkName { get; set; }
        public string LandmarkLat { get; set; }
        public string LandmarkLng { get; set; }
        public string Description { get; set; }
        public string LandmarkImage { get; set; }

    }
}
