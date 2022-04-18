import axios from 'axios';

const path =  '/itinerary';

export default {

  getItinerary(itineraryId) {
    return axios.get(path + '/fetch/' + itineraryId)
  },

  getItineraries() {
    return axios.get(path + '/fetch/')
  },

  getUserItineraries(userId) {
    return axios.get(path + '/fetchuser/' + userId)
  },

  getItineraryDetails(itineraryId) {
    return axios.get(path + '/fetch/details/' + itineraryId)
  },

  addItinerary(itinerary, userId) {
    return axios.post(path + '/add', itinerary, userId)
  },

  deleteItinerary(itineraryId) {
      return axios.delete(path + '/delete/' + itineraryId)
  },

  deleteLandmarkFromItinerary(itineraryDetails) {
      return axios.delete(path + '/deletelandmark', itineraryDetails)
  },

<<<<<<< HEAD
  addLandmarkToItinerary(itineraryDetails) {
      return axios.post(path + '/addlandmark', itineraryDetails)
  },
  
=======
  addLandmarkToItinerary(itineraryId, landmarkId, userId) {
      return axios.post(path + '/addlandmark', itineraryId, landmarkId, userId)
  }
>>>>>>> 1aa9342b3ec39fe9e92dcd4a535d2ffcdf860bb7
}