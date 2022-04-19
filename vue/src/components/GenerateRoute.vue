<template>
  <h1></h1>
</template>

<script>
import Map from './components/Map.vue'
import landmarksService from "../services/LandmarksService.js";
export default {
    
components: { Map },
name: 'Generate Travel Route',
data() {
    return {
      
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      
    };
},








</script>

