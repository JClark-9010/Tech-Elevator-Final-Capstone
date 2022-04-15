<template>
  <div>
    <form v-on:submit.prevent="onSubmit">
      <div>
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="itinerary.itineraryName"
        />
      </div>
      <input type="submit" />
      <input type="button" v-on:click.prevent="resetForm" value="Cancel" />
    </form>
    <h2 v-if="itineraryCreated"> Add some landmarks to your itinerary</h2>
    <landmarks-overview v-if="itineraryCreated" />
    
  </div>


</template>

<script>
import itineraryService from "../services/ItineraryService.js";
import LandmarksOverview from "../components/LandmarksOverview.vue";

export default {
  name: "create-itinerary",
  components: { LandmarksOverview },
  data() {
    return {
      itinerary: {
        userId: this.$store.state.user.userId,
      },
      
    };
  },
  
  methods: {
    onSubmit() {
      this.$store.commit("ADD_ITINERARY", this.itinerary, this.userId);
      this.itineraryCreated=true;
      this.$store.state.inItinerary=true;
      itineraryService
        .addItinerary(this.itinerary, this.userId)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "itinerary" });
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
      this.resetForm();
    },

    resetForm() {
      this.itinerary = {};
    },

    created() {},
  },
  
};
</script>
