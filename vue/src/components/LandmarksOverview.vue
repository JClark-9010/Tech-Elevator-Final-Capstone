<template>
  <div>
    
        <div id="landmarkCard" v-for="landmark in landmarks" v-bind:key="landmark.landmarkId" v-on:click="viewLandmarkDetails(landmark.landmarkId)">
          <h4>
            {{ landmark.landmarkName }}
          </h4>
          <!-- <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td> -->
          <p>{{ landmark.description }}</p>
          <img v-bind:src="landmark.landmarkImage" alt="">
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
  grid-template-columns: 1fr 1fr;
  grid-template-rows:1fr 1fr;
  grid-template-areas: 
  "h4 img"
  "para img";
}
h4{
  grid-area: h4;
  text-align: center;
  padding-top: 40px;
}
p{
  grid-area: para;
}
img{
  max-width: 100px;
  grid-area: img;
}
</style>