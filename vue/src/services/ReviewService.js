import axios from 'axios';

const path =  '/reviews';

export default {

  getReviews(landmarkId) {
    return axios.get(path + '/' + landmarkId)
  },

  getReview(reviewId) {
    return axios.get(path +'/' + reviewId)
  },

  addReview(newReview) {
    return axios.post(path + '/new-review', newReview)
  },
  
}