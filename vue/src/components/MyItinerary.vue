<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/ping_pong_loader.gif" />
  </div>
  <div v-else>
    <h2>{{ itinerary.itineraryName }}</h2>
    </div>
</template>

<script>
import itineraryService from "../services/ItineraryService.js";
export default {
 data() {
    return {
      isLoading: true,
    };
  },
  methods: {
    getUserItinerary() {
      itineraryService
        .getItinerary(this.$route.params.itineraryId).then((response) => {
        this.$store.commit("SET_CURRENT_ITINERARY", response.data);
        this.isLoading = false;
      });
    },
  },
  created() {
    this.getUserItinerary();
  },
  computed: {
    itinerary() {
        return this.$store.state.itinerary;
      },
  },
}
</script>

<style>

</style>