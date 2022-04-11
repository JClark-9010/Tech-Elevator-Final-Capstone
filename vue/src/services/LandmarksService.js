import axios from 'axios';

const path =  '/landmarks';

export default {

  getLandmarks() {
    return axios.get(path)
  },

  getLandmark(landmarkName) {
    return axios.get(path +'/' + landmarkName)
  },

  addLandmark(landmark) {
    return axios.post(path, landmark)
  },


}