<template>
  <div>
    
    <Map/>
  
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
import Map from "../components/Map.vue";

export default {
  name: "nearby",
  data(){
    
  },
  components: {
    Map,
  },
  methods: {
    getDistance(){
      this.userCoordinates.lat
    }


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
</style>