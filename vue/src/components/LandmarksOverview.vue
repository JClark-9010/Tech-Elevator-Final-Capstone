<template>
  <div id="overview">
    
        <div id="landmarkCard" v-for="landmark in landmarks" v-bind:key="landmark.landmarkId" v-on:click="viewLandmarkDetails(landmark.landmarkId)">
          <h5>
            {{ landmark.landmarkName }}
          </h5>
          <!-- <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td> -->
          <!-- <p>{{ landmark.description }}</p> -->
          <img id="detImage" v-bind:src="landmark.landmarkImage" alt="">
          <button v-on:click.prevent="addLandmarkToItinerary" v-if="checkItinerary">Add Landmark to Itinerary</button>
        </div>
      
  </div>
</template>

<script>

import landmarksService from "../services/LandmarksService.js";
export default {
  name: "LandmarksOverview",
  data () {
    return {
      userId: this.$store.state.user.userId
    }
  },
  methods: {
    viewLandmarkDetails(landmarkId) {
      this.$router.push(`/landmarks/${landmarkId}`);
    },
    addLandmarkToItinerary(){
      this.$store.commit("ADD_LANDMARK_TO_ITINERARY", this.itinerary.itineraryId, this.landmark.landmarkId, this.userId);
      this.$router.push({ name: "itinerary" });
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
#overview{
  display: flex;
  flex-wrap: wrap;
  padding-left: 25px;
  
}
#landmarkCard{
  border-style: solid;
  border-color: black;
  padding-left: 20px;
  padding-right:20px;
  border-radius: 20px;
  display: grid;
  flex-wrap: wrap;
  
  grid-template-columns: 250px;
  grid-template-rows: 70px 175px 70px;
  grid-template-areas: 
  "h5"
  "img"
  "button";
  box-shadow: 3px 3px gray;
  margin: 20px;
  background-color: whitesmoke;
}
#landmarkCard:hover{
  background-color: white;
  box-shadow: 5px 5px 5px 5px gray;
}
h5{
  grid-area: h5;
  text-align: center;
  padding-top: 10px;
}
p{
  grid-area: para;
  font-size: 12px;
  
}
#detImage{
  max-width: 250px;
  max-height: 175px;
  grid-area: img;
  
  
}
button{
  background-color: rgb(12, 204, 211);
  height: 50px;
  justify-content: center;
  grid-area: button;
  border:black;
  border-radius: 5px;
  
  
  
  
}
button:hover{
  box-shadow: 2px 2px 2px 2px gray;
}
</style>