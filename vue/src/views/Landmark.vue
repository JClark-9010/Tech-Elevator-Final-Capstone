<template>
  <div>
    <landmark-details v-bind:name="landmarkName"/>
  </div>
</template>

<script>
import LandmarkDetails from "../components/LandmarkDetails.vue";
export default {
    name: "Landmark",

    components: { LandmarkDetails },

    computed: {
        product() {
            return this.$store.state.landmarks.find(
                l => l.landmarkName == this.$store.state.activeLandmark
            );
        }
    },

  data() {
    return {
      landmarkName: "",
    };
  },

  created() {
    const activeLandmarkName = this.$route.params.name;
    this.$store.commit("SET_ACTIVE_LANDMARK", activeLandmarkName)
  },
};
</script>

<style>
</style>