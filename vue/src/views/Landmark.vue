<template>
  <div>
  <landmark-details />
  <reviews />

  </div>
</template>

<script>
import LandmarkDetails from "../components/LandmarkDetails.vue";
import Reviews from "../components/Reviews.vue";
export default {
  components: {
    LandmarkDetails,
    Reviews,
  },
};
</script>

<style>
</style>