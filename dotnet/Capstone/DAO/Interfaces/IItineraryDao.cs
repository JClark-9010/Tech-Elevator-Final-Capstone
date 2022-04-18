using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IItineraryDAO
    {
        //GET ALL USER'S ITINERARIES
        List<Itinerary> RetrieveUserItineraries(int userId);
        //CREATE NEW ITINERARY
        bool AddItinerary(Itinerary itinerary);
        //DELETE ENTIRE ITINERARY
        bool DeleteItinerary(int itineraryId);
        //REMOVE A LANDMARK FROM ITINERARY
        bool DeleteLandmarkFromItinerary(ItineraryDetails i);
        //GET ITINERARY AND ALL LANDMARKS ON IT
        List<ItineraryDetails> GetItineraryDetails(int itineraryId);
        //ADD A LANDMARK TO ITINERARY
       // bool AddLandmarkToItinerary(ItineraryDetails i);
        //GET/SET THE CURRENT ITINERARY
        Itinerary GetItinerary(int itineraryId);
        //GET ALL ITINERARIES IN DATABASE
        List<Itinerary> GetItineraries();

        bool AddLandmarkToItinerary(int itineraryId, int landmarkId, int userId);
    }
}

