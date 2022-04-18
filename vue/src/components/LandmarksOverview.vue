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
          <button v-on:click.prevent="addLandmarkToItinerary" v-if="inItinerary">Add Landmark to Itinerary</button>
          <!-- <button v-else>Add Landmark to Itinerary></button> -->
        </div>
      
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
export default {
  name: "LandmarksOverview",
  data () {
    return {
      userId: this.$store.state.user.userId,
      timeToAdd: this.$store.state.timeToAdd,
      itineraryDetails: {},
      itineraryId: this.$store.state.itineraryId
    }
  },
  methods: {
    viewLandmarkDetails(landmarkId) {
      this.$router.push(`/landmarks/${landmarkId}`);
    },
    addLandmarkToItinerary(){
      this.$store.commit("ADD_LANDMARK_TO_ITINERARY", this.itineraryDetails);
      landmarksService.updateLandmark(this.itineraryId, this.landmarkId);
      this.$router.push({ name: "itinerary" });
    },
  },
  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    inItinerary() {
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
  /* border-style: solid; */
  border-color: black;
  padding-left: 20px;
  padding-right:20px;
  border-radius: 20px;
  display: grid;
  flex-wrap: wrap;
  color: #EAD6C7;
  
  grid-template-columns: 250px;
  grid-template-rows: 175px 70px 70px;
  grid-template-areas: 
  "img"
  "h5"
  "button";
 
  margin: 20px;
  background-color: #E57D6A;
}
#landmarkCard:hover{
  background-color: #1A5270;

  
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
  padding-top: 10px;
  
  
}
button{
  background-color: #208B77;
  height: 50px;
  justify-content: center;
  grid-area: button;
  border:black;
  border-radius: 5px;
  color:#EAD6C7;
  
  
  
}
button:hover{
 border: #EAD6C7;
 border-style: solid;
 border-radius: 6px;
}
</style>