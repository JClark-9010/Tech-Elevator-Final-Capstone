<template>
  <div>
    <h1 v-if="successfullyAdded">Landmark added to your itinerary!</h1>
    <div
      id="itineraryCard"
      v-for="itinerary in userItineraries"
      v-bind:key="itinerary.itineraryId"
      v-on:click="getUserItinerary(itinerary.itineraryId)"
    >
      <h5>{{ itinerary.itineraryName }}</h5>
    <h2 v-if="itinerarySelected">Add some landmarks to your itinerary</h2>
    
    <landmarks-overview v-if="itinerarySelected" />
    </div>
  </div>
    <!-- <div v-else>
       <div
        id="itineraryCard"
        v-for="itinerary in itineraries"
        v-bind:key="itinerary.itineraryId"
        v-on:click="viewItineraryDetails(itineraryId)"
      >
      <h5>{{ itinerary.itineraryName }}</h5>
    </div>
    </div> -->
</template>

<script>
import LandmarksOverview from "../components/LandmarksOverview.vue";
import itineraryService from "../services/ItineraryService.js";
export default {
  name: "my-itineraries",
  components: { LandmarksOverview },
  data() {
    return {
      successfullyAdded: false,
      itinerarySelected: false,
      userId: this.$store.state.user.userId,
    };
  },
  methods: {
    getUserItinerary(itineraryId) {
      this.$router.push({name: 'itinerary-details', params: {itineraryId: itineraryId}});
      this.itinerarySelected = true;
    },
    viewItineraryDetails(itineraryId) {
      this.$router.push(`/my-itineraries/${itineraryId}`);
    }
  },
  created() {
    itineraryService.getUserItineraries(this.userId).then((response) => {
      this.$store.commit("REPLACE_USER_ITINERARIES", response.data);
    });
    itineraryService.getItineraries().then((response) => {
      this.$store.commit("REPLACE_ITINERARIES", response.data);
    });
  },
  computed: {
    userItineraries() {
      return this.$store.state.userItineraries;
    },
    itineraries() {
      return this.$store.state.itineraries;
    },
    itinerary() {
      return this.$store.state.itinerary;
    },
    
  },
};
</script>

<style>
</style>