<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/globe.gif" />
  </div>
  <div id="details" v-else>
    
    <h2 id="name">{{ landmark.landmarkName }}</h2>
    <h4 id="description">{{ landmark.description }}</h4>
    <img id="image" v-bind:src="landmark.landmarkImage" alt="">
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService";


export default {
  name: "landmark-detail",
  data() {
    return {
      isLoading: true,
    };
  },
  methods: {
    retrieveLandmark() {
      landmarksService
        .getLandmark(this.$route.params.landmarkId).then((response) => {
          this.$store.commit("SET_CURRENT_LANDMARK", response.data);
          this.isLoading = false;
        });
    },
  },
  created() {
    this.retrieveLandmark();
    this.$store.commit("USER_NOT_IN_ITINERARY");
  },

  computed: {
    landmark() {
      return this.$store.state.landmark;
    },
  },
};
</script>

<style>
#details{
  display: grid;
  grid-template-rows: 1fr 9fr ;
  grid-template-columns: 1fr 2fr;
  grid-template-areas: 
  "name name"
  "img description" ;
  
  
}
h2{
  font-style: bold;
}
#image{
  max-width: 500px;
  grid-area: img;
  padding-left: 40px;
}
#name{
  padding-left: 40px;
  grid-area: name;
  justify-content: center;
}
#description{
  grid-area: description;
   color: #EAD6C7;
  margin-bottom: 200px;
  margin-left: 20px;
  margin-right: 20px;
  padding: 15px;
  border-style: solid;
  font-size: 22px;
  border-radius: 10px;
  background-color: #1A5270;
}

</style>
