<template>
  <div>
    <table>
      <tbody>
      
        <tr v-for="(landmark, index) in landmarks" v-bind:key="index">
          <td>{{ landmark.landmarkId }}</td>
          <td>
            <router-link v-bind:to="{name: 'Landmark', params: { name: landmark.landmarkName}}" >{{ landmark.landmarkName }}</router-link>
            </td>
          <td>{{ landmark.zipcode }}</td>
          <td>{{ landmark.description }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
export default {
  name: "LandmarksOverview",

  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    searchLandmark(){
      let filteredLandmarks = this.landmarks;
      if(this.filter.landmarkName != ""){
        filteredLandmarks =filteredLandmarks.filter(  (landmark) => 
        landmark.landmarkName.toLowerCase().includes(this.filter.landmarkName.toLowerCase())
            
          )
      }
          return filteredLandmarks;
      
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