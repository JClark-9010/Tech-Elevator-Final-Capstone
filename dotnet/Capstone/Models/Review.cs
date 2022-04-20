using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int LandmarkId { get; set; }
        public string Description { get; set; }
    }
}
