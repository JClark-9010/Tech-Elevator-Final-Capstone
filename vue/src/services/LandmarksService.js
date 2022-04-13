import axios from 'axios';

const path =  '/landmarks';

export default {

  getLandmarks() {
    return axios.get(path)
  },

  getLandmark(landmarkId) {
    return axios.get(path +'/' + landmarkId)
  },

  addLandmark(landmark) {
    return axios.post(path, landmark)
  },

  // landmarksNearMe(userLat, userLng) {
  //   // take users coordinates and return all landmarks within 20 miles

  //   return axios.get(path, )
  // }
}