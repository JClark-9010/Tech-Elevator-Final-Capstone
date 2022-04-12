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


}