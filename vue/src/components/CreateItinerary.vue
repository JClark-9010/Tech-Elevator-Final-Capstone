<template>
  <div id="createItinerary">
    <form v-on:submit.prevent="onSubmit">
      <div>
        <label id="typeName" for="name">Type in a name for your itinerary: </label>
        <input
          required
          type="text"
          id="inputName"
          name="name"
          class="form-control"
          v-model="itinerary.itineraryName"
        />
      </div>
      <div id="spacer"></div>
      <input type="submit" id="submit"/>
      <input type="button" v-on:click.prevent="resetForm" value="Cancel" id="cancel" />
    </form>
  </div>
</template>

<script>
import itineraryService from "../services/ItineraryService.js";

export default {
  name: "create-itinerary",

  data() {
    return {
      
      itinerary: {
        userId: this.$store.state.user.userId,
      },
    };
  },

  methods: {
    onSubmit() {
      this.$store.state.inItinerary = true;
      itineraryService
        .addItinerary(this.itinerary, this.userId)
        .then((response)  =>  {
           this.$store.commit("ADD_ITINERARY", response.data)
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        }).then(itineraryService.getUserItineraries(this.userId).then((response) => {
      this.$store.commit("REPLACE_USER_ITINERARIES", response.data);
    }))
      
      
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
  #createItinerary{
    margin-left: 20px;
    
  }
  #typeName{
    font-size: 20px;
    padding-left: 0px;
    padding-top: 10px;
  }
 #inputName{
   width: 835px;
   margin-bottom: 10px;
 }
 
</style>
