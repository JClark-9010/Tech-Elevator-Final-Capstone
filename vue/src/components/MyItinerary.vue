<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/ping_pong_loader.gif" />
  </div>
  <div v-else >
    <h2>{{ itinerary.itineraryName }}</h2>
    <div v-for="addedLandmark in itineraryDetails" v-bind:key="addedLandmark.landmarkId">
    <p>{{addedLandmark.landmarkName}}</p>
    <p>{{addedLandmark.description}}</p>
    <button v-on:click="deleteLandmark(addedLandmark.itineraryId, addedLandmark.landmarkId)"> Placeholder </button>
    </div>
    <h3>Want to add some places to visit?</h3>
    <landmarks-overview />
  </div>
</template>

<script>
import itineraryService from "../services/ItineraryService.js";
import LandmarksOverview from "../components/LandmarksOverview.vue";

export default {
  components: { LandmarksOverview },
  data() {
    return {
      isLoading: true,
    };
  },

  methods: {
    getUserItinerary() {
      itineraryService
        .getItinerary(this.$route.params.itineraryId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_ITINERARY", response.data);
        });
          
          
           
    },
    getDetails(){
      itineraryService
        .getItineraryDetails(this.$route.params.itineraryId)
        .then((response) => {
        this.$store.commit("SET_CURRENT_ITINERARY_DETAILS", response.data);
        this.isLoading = false;
         

      });
    },
    deleteLandmark(itineraryId, landmarkId){
      itineraryService
        .deleteLandmarkFromItinerary(itineraryId, landmarkId)
        .then((response) => {
        this.$store.commit("SET_CURRENT_ITINERARY_DETAILS", response.data);
        location.reload();
      });
    }
  },
  created() {
    this.getUserItinerary();
    this.getDetails();
    this.$store.commit("USER_IN_ITINERARY");
  },
  mounted() {
        location.commit();
  },


  computed: {
    itinerary() {
      return this.$store.state.itinerary;
    },
    itineraryDetails() {
      return this.$store.state.itineraryDetails;
    },
  },
};
</script>

<style>
</style>