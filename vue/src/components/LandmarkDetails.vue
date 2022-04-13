<template>
  <div>
    <h1>{{landmark.landmarkName}}</h1>
    <h3>{{landmark.description}}</h3>
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService";

export default {
  name: "landmark-detail",

  methods: {
    retrieveLandmark() {
      landmarksService
        .getLandmark(this.$route.params.landmarkId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_LANDMARK", response.data);
        });
    },
  },

  created() {
    this.retrieveLandmark();
  },

  computed: {
    landmark() {
      return this.$store.state.landmark;
    },
  },
};
</script>

<style>
</style>
