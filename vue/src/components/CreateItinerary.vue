<template>
  <div id="createItinerary">
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
  </div>
</template>

<script>
import itineraryService from "../services/ItineraryService.js";

export default {
  name: "create-itinerary",

  data() {
    return {
      itineraryCreated: false,
      itinerary: {
        userId: this.$store.state.user.userId,
      },
    };
  },

  methods: {
    onSubmit() {
      this.$store.commit("ADD_ITINERARY", this.itinerary, this.userId);
      this.itineraryCreated = true;
      this.$store.state.inItinerary = true;
      itineraryService
        .addItinerary(this.itinerary, this.userId)
        .then((response) => {
          console.log("promise was success", response);
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
      itineraryService.getItineraries().then((response) => {
        this.$store.commit("REPLACE_ITINERARIES", response.data);
      });
      this.$router.push({ name:"my-itineraries"});
    },
  },
  
  resetForm() {
    this.itinerary = {};
  },
  created() {},
};
</script>

<style>
#createItinerary {
  margin-left: 20px;
}
#createItinerary {
  margin-right: 300px;
}
</style>
