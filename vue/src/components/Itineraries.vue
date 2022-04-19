<template>
  <div>
    <h1 v-if="successfullyAdded">Landmark added to your itinerary!</h1>
    <div
      v-for="itinerary in userItineraries"
      v-bind:key="itinerary.itineraryId"
    >
      <h5 v-on:click="getUserItinerary(itinerary.itineraryId)" id="itineraryName">{{ itinerary.itineraryName }}</h5>
      <button v-on:click="deleteItinerary(itinerary.itineraryId)" > Delete Itinerary </button>
    
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
<<<<<<< HEAD
     
=======
>>>>>>> a0764bbe0f2ff76005e60728554e7657048fd3fa
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
<<<<<<< HEAD
    
=======
>>>>>>> a0764bbe0f2ff76005e60728554e7657048fd3fa
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
#itineraryName{
  margin: 20px;
  padding: 5px;
  border-radius: 5px;
  background-color: #E57D6A;
  margin-right: 800px;
  color: #EAD6C7;
}
#itineraryName:hover{
  background-color: #1A5270;
}

</style>