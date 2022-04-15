<template>
  <div>
    
        <div id="landmarkCard" v-for="landmark in landmarks" v-bind:key="landmark.landmarkId" v-on:click="viewLandmarkDetails(landmark.landmarkId)">
          <h5>
            {{ landmark.landmarkName }}
          </h5>
          <!-- <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td> -->
          <p>{{ landmark.description }}</p>
          <img id="image" v-bind:src="landmark.landmarkImage" alt="">
          <button v-if="checkItinerary">Add Landmark to Itinerary</button>
        </div>
      
  </div>
</template>

<script>

import landmarksService from "../services/LandmarksService.js";
export default {
  name: "LandmarksOverview",
  
  methods: {
    viewLandmarkDetails(landmarkId) {
      this.$router.push(`/landmarks/${landmarkId}`);
    },
  },
  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    checkItinerary() {
      return this.$store.state.inItinerary;
    }
  },
  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
    
  },
};
</script>

<style>
#landmarkCard{
  border-style: solid;
  border-color: black;
  padding-left: 20px;
  border-radius: 20px;
  display: grid;
  grid-template-columns: 200px auto;
  grid-template-rows:100px 135px 100px;
  grid-template-areas: 
  "h5 img"
  "para img"
  "button img";
  box-shadow: 3px 3px gray;
  margin: 20px;
  background-color: whitesmoke;
}
h5{
  grid-area: h5;
  justify-content: center;
  align-items: center;
  padding-top: 40px;
}
p{
  grid-area: para;
  font-size: 10px;
}
#image{
  max-height: 275px;
  grid-area: img;
  padding-left: 100px;
  padding-top: 50px;
}
button{
  background-color: #4CAF50; /* Green */
  height: 50px;
  justify-content: center;
  grid-area: button;
}
</style>