<template>
  <div>
    <Map />    
     <table>
      <tbody>
        <tr v-for="landmark in landmarks" v-bind:key="landmark.landmarkId">
          <td >
            {{ landmark.landmarkName }}
          </td>
          <td>{{distance(40, -83, 45, -80)}}</td>
        </tr>
      </tbody>
    </table>
    
 </div>
  
 
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
import Map from "../components/Map.vue";





export default {
  name: "nearby",

  

  components: {
    Map,
  },
  //getDistance method = claculate distance between user coordinates and landmark coordinates
  //loop through landmarks forEach landmark lat and lng
  //using getDistance to find distance of each landmark from user
  //returning landmarks with certain radius or closest landmark
  //

  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    closest(landmarks){
      let d = landmarks.forEach(  (landmark) => {
        return  this.distance(40, -80, landmark.landmarkLat, landmark.landmarkLng)
      });
      
      return d
    },
    
  },
  methods:{
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
  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
  
  },
};
</script>

<style>
</style>