<template>
  <div>
    <h1 v-if="successfullyAdded">Landmark added to your itinerary!</h1>
    <div id="itinerariesGrid"
      v-for="itinerary in userItineraries"
      v-bind:key="itinerary.itineraryId"
    >
      <h5 v-on:click="getUserItinerary(itinerary.itineraryId)" id="itineraryName">{{ itinerary.itineraryName }}</h5>
      <button id="deleteEntire" v-on:click="deleteItinerary(itinerary.itineraryId)" > Delete Itinerary </button>
    
    <landmarks-overview v-if="itinerarySelected" />
    </div>
  </div>
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
      itineraryService
        .getItinerary(itineraryId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_ITINERARY", response.data);
          
        }).then( this.$router.push({name: 'itinerary-details', params: {itineraryId: itineraryId}}));
    },
    
    
    viewItineraryDetails(itineraryId) {
      this.$router.push(`/my-itineraries/${itineraryId}`);
    },
    deleteItinerary(itineraryId) {
      console.log(itineraryId);
      itineraryService.deleteItinerary(itineraryId);
      itineraryService.getUserItineraries(this.userId).then((response) => {
      this.$store.commit("REPLACE_USER_ITINERARIES", response.data);
    });
      location.reload();
    },
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
#itinerariesGrid{
  display: grid;
  grid-template-columns: 200px 1fr;
}

#itineraryName{
  margin: 20px;
  padding: 5px;
  border-radius: 5px;
  background-color: #E57D6A;
 
  color: #EAD6C7;
}
#itineraryName:hover{
  background-color: #1A5270;
}

</style>