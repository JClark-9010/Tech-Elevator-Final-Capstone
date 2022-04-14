using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IItineraryDAO
    {
        List<Itinerary> RetrieveItineraries(int userId);
        bool AddItinerary(Itinerary itinerary);
        bool DeleteItinerary(int itineraryId);
        bool EditItinerary(Itinerary itinerary);

        //List<Landmark> RetrieveItineraryDetails(int userId, int itineraryId);

    }
}

