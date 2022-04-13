<template>
  <div>
    <landmark-details v-bind:name="landmarkName"/>
    <add-landmark/>
  </div>
</template>

<script>
import LandmarkDetails from "../components/LandmarkDetails.vue";
import AddLandmark from "../components/AddLandmark.vue";
export default {
    name: "Landmark",

    components: { LandmarkDetails, AddLandmark },

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