import axios from 'axios';

const path =  '/reviews';

export default {

  getReviews(landmarkId) {
    return axios.get(path + '/' + landmarkId)
  },

  getReview(reviewId) {
    return axios.get(path +'/' + reviewId)
  },

  addReview(landmarkId, description) {
    return axios.post(path + 'new-review', landmarkId, description)
  },
  
}