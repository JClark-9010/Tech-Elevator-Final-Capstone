<template>
  <div id="Map">
    <Map />

  </div>
</template>

<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnRbD3j0M-BIHvJ6vVwTpe7iVOxZGNuEo&libraries=places">
import Map from './components/Map.vue'
// import landmarksService from "../services/LandmarksService.js";
export default {
    
components: { Map },
name: 'Generate Travel Route',
data() {
    return {
      
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
       mapCoordinates: {
        lat: 0,
        lng: 0,
      },


      mounted() {
        let map = this.$ref.mapRef;
        map.displayRoute(
          {
              lat: this.userCoordinates.lat,
              lng: this.userCoordinates.lng
          },
          {
            lat: this.mapCoordinates.lat,
            lng: this.mapCoordinates.lng,
          },
        ) 
        

      }
      
    };
}};








</script>

