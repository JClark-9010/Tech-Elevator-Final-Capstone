<template>
  <div id="overview">
    
        <div id="landmarkCard" v-for="landmark in landmarks" v-bind:key="landmark.landmarkId">
          <h5 v-on:click="viewLandmarkDetails(landmark.landmarkId)">
            {{ landmark.landmarkName }}
          </h5>
          
          <!-- <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td> -->
          <!-- <p>{{ landmark.description }}</p> -->
          <img id="detImage" v-bind:src="landmark.landmarkImage" alt="" v-on:click="viewLandmarkDetails(landmark.landmarkId)">
          <!-- <button v-else>Add Landmark to Itinerary></button> -->
          <button v-if="inItinerary" v-on:click="addLandmarkToItinerary(landmark.landmarkId)">Add Landmark to Itinerary</button>
        </div>
      
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
import itineraryService from "../services/ItineraryService.js";
export default {
  name: "LandmarksOverview",
  data () {
    return {
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
    }
  },
  methods: {
    viewLandmarkDetails(landmarkId) {
      this.$router.push(`/landmarks/${landmarkId}`);
    },
      
     
    addLandmarkToItinerary(landmarkId){
      console.log(this.itineraryId, landmarkId, this.$store.state.user.userId)
      itineraryService.addLandmarkToItinerary(this.itineraryId, landmarkId, this.$store.state.user.userId);
      itineraryService.getItinerary(this.itineraryId).then((response) => {
      this.$store.commit("SET_CURRENT_ITINERARY", response.data)}).then((newResult) => location.reload(newResult));
    },
    
    distance(lat1, lng1, lat2, lng2) {
      const R = 3958.8;
      let dLat = this.deg2rad(lat2 - lat1);
      let dLng = this.deg2rad(lng1 - lng2);
      let a =
          Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(this.deg2rad(lat1)) *
          Math.cos(this.deg2rad(lat2)) *
          Math.sin(dLng / 2) *
          Math.sin(dLng / 2);
      let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
      let d = R * c;
      return d;
    },
    deg2rad(deg) {
      return deg * (Math.PI / 180);
    },
  },
  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    inItinerary() {
      return this.$store.state.inItinerary;
    },
    itineraryDetails() {
      return this.$store.state.itineraryDetails;
    },
    sortLandmarks(){
      let sortedLandmarks = this.$store.state.landmarks.slice();
        return sortedLandmarks.sort((a, b) => {
        return this.distance(this.userCoordinates.lat, this.userCoordinates.lng, a.landmarkLat, a.landmarkLng) -
        this.distance(this.userCoordinates.lat, this.userCoordinates.lng, b.landmarkLat, b.landmarkLng)})
    },
    itineraryId(){
      return this.$store.state.itinerary.itineraryId
    },
  },
  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
    this.$getLocation({})
        .then((coordinates) => {
          this.userCoordinates = coordinates;
        })
        .catch((error) => alert(error));
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
  padding-left: 25px;
  padding-right:25px;
  padding-top: 5px;
  border-radius: 20px;
  display: grid;
  flex-wrap: wrap;
  color: #EAD6C7;
  
  grid-template-columns: 240px;
  grid-template-rows: 175px 85px 70px;
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
  margin-top: 15px;
  
}
p{
  grid-area: para;
  font-size: 12px;
  
}
#detImage{
  width: 240px;
  /* max-height: 175px; */
  grid-area: img;
  margin-top: 10px;
  
  
}
#detImage:hover{
 border: #EAD6C7;
 border-style: solid;
 border-radius: 6px;
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