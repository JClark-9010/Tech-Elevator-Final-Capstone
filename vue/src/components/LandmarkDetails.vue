<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/ping_pong_loader.gif" />
  </div>
  <div v-else>
    <h1>Patrick, please don't screw this up</h1>
    <h2>{{ landmark.landmarkName }}</h2>
    <h4>{{ landmark.description }}</h4>
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService";

export default {
  name: "landmark-detail",
  data() {
    return {
      isLoading: true,
    };
  },
  methods: {
    retrieveLandmark() {
      landmarksService
        .getLandmark(this.$route.params.landmarkId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_LANDMARK", response.data);
          this.isLoading = false;
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
