<template>
  <div>
    <table>
      <tbody>
        <tr v-for="landmark in landmarks" v-bind:key="landmark.landmarkId">
          <td>{{ landmark.landmarkId }}</td>
          <td v-on:click="viewLandmarkDetails(landmark.landmarkId)">
            {{ landmark.landmarkName }}
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
  //   searchLandmark(){
  //     let filteredLandmarks = this.landmarks;
  //     if(this.filter.landmarkName != ""){
  //       filteredLandmarks =filteredLandmarks.filter(  (landmark) =>
  //       landmark.landmarkName.toLowerCase().includes(this.filter.landmarkName.toLowerCase())

  //         )
  //     }
  //         return filteredLandmarks;

  //   },
  // },

  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
  },
};
</script>

<style>
</style>