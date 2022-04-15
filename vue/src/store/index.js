import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    inItinerary: false,
    landmarks: [],
    itineraries: [],
    itineraryDetails: [],
    distances: [],
  },

  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },

    REPLACE_LANDMARKS(state, landmarks) {
      state.landmarks = landmarks;
    },
    SET_CURRENT_LANDMARK(state, data){
      state.landmark = data;
    },
    ADD_LANDMARK(state,landmark){
      state.landmarks.push(landmark);
    },

    REPLACE_ITINERARIES(state, itineraries){
      state.itineraries = itineraries;
    },
    SET_CURRENT_ITINERARY(state, data){
      state.itinerary = data;
    },
    ADD_ITINERARY(state, itinerary, userId){
      state.itineraries.push(itinerary, userId);
    },
  }
})
