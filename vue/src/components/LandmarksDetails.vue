<template>
  <div>
      <p> HEY </p>
    <table>
      <tbody>
        <tr v-for="(landmark, index) in landmarks" v-bind:key="index">
          <td>{{ landmark.landmarkId }}</td>
          <td>{{ landmark.landmarkName }}</td>
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
  name: "LandmarksDetails",

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