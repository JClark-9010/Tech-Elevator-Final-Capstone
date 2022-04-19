<template>
  <div>
    <div id="itinerariesGrid" v-for="itinerary in userItineraries" v-bind:key="itinerary.itineraryId">
      <h5 v-on:click="getUserItinerary(itinerary.itineraryId)" id="itineraryName">{{ itinerary.itineraryName }}</h5>
      <button id="deleteEntire" v-on:click="deleteItinerary(itinerary.itineraryId)" > Delete Itinerary </button>
    </div>
  </div>
</template>

<script>
import itineraryService from "../services/ItineraryService.js";
export default {
  name: "my-itineraries",
  components: { },
  data() {
    return {
      userId: this.$store.state.user.userId,
    };
  },
  methods: {
    getUserItinerary(itineraryId) {
      this.$router.push(`/my-itineraries/${itineraryId}`);
    },
    promptAssurance(itineraryId){
      this.selected = true;
      this.$store.commit("SET_STORE_ITINERARY", itineraryId);
      console.log(this.storeItinerary)
    },
    deleteItinerary(itineraryId) {
      console.log(itineraryId);
      itineraryService.deleteItinerary(itineraryId);
      itineraryService.getUserItineraries(this.userId).then((response) => {
      this.$store.commit("REPLACE_USER_ITINERARIES", response.data);
    })},
  },
  created() {
    itineraryService.getUserItineraries(this.userId).then((response) => {
      this.$store.commit("REPLACE_USER_ITINERARIES", response.data);
    });
  },
  computed: {
    userItineraries() {
      return this.$store.state.userItineraries;
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