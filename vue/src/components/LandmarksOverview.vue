<template>
  <div>
    <table>
      <tbody>
        <tr v-for="landmark in landmarks" v-bind:key="landmark.landmarkId">
          <td v-on:click="viewLandmarkDetails(landmark.landmarkId)">
            {{ landmark.landmarkName }}
          </td>
          <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td>
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
        //40.19191 N, 83,9000 W

  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
  },
};
</script>

<style>
</style>