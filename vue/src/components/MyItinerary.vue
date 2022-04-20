<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/globe.gif" />
  </div>
  <div v-else>
    <!-- <h2>{{itinerary.itineraryName}}</h2> -->
    <div id="itineraryOverview">
      <!-- <h2 id="itineraryNameView">{{ itinerary.itineraryName }}</h2> -->
      <div
        id="itineraryCard"
        v-for="addedLandmark in itineraryDetails"
        v-bind:key="addedLandmark.landmarkId">
        <h5 id="addedName">
          {{ addedLandmark.landmarkName }}
        </h5>

        <img id="addedImage" v-bind:src="addedLandmark.landmarkImage" alt="" />

        <button
          id="deleteAdded"
          v-on:click="
            deleteLandmark(addedLandmark.itineraryId, addedLandmark.landmarkId)
          "
        >
          Delete From Itinerary
        </button>
      </div>
    </div>
    <h3>Want to add some places to visit?</h3>
    <div>
      <landmarks-overview />
      
    </div>
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
    getDetails() {
      itineraryService
        .getItineraryDetails(this.$route.params.itineraryId).then((response) => {
          this.$store.commit("SET_CURRENT_ITINERARY_DETAILS", response.data);
          this.isLoading = false;
        });
    },

   
    deleteLandmark(itineraryId, landmarkId) {
      itineraryService
        .deleteLandmarkFromItinerary(itineraryId, landmarkId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_ITINERARY_DETAILS", response.data);
        })
        .then((newResult) => location.reload(newResult));
    },
  },

  created() {
    itineraryService.getItinerary(this.$route.params.itineraryId).then((response) => {
      this.$store.commit("SET_CURRENT_ITINERARY", response.data);
    })
    this.getDetails();
    this.$store.commit("USER_IN_ITINERARY");
  },
  mounted() {},

  computed: {
    itineraryDetails() {
      return this.$store.state.itineraryDetails;
    },
    itinerary() {
      return this.$store.state.itinerary;
    }
  },
};
</script>

<style>
h3 {
  color: #1a5270;
  margin-left: 20px;
}
#itineraryOverview {
  display: flex;
  flex-wrap: wrap;
  padding-left: 25px;
}
#itineraryCard {
  padding-left: 25px;
  padding-right: 25px;
  padding-top: 5px;
  border-radius: 20px;
  display: grid;

  color: #ead6c7;

  grid-template-columns: 240px;
  grid-template-rows: 175px 85px 70px;
  grid-template-areas:
    "addedImage"
    "addedName"
    "deleteAdded";

  margin: 20px;
  background-color: #1a5270;
}
#addedName {
  grid-area: addedName;
  text-align: center;
  margin-top: 15px;
}
#addedImage {
  width: 240px;
  /* max-height: 175px; */
  grid-area: addedImage;
  margin-top: 10px;
}
#deleteAdded {
  background-color: #208b77;
  height: 50px;
  justify-content: center;
  grid-area: deleteAdded;
  border: black;
  border-radius: 5px;
  color: #ead6c7;
}
#deleteAdded:hover {
  border: #ead6c7;
  border-style: solid;
  border-radius: 6px;
}
#itineraryNameView {
  margin: 20px;
  padding: 5px;
  border-radius: 5px;
  background-color: #1a5270;
  margin-right: 800px;
  color: #ead6c7;
}
</style>