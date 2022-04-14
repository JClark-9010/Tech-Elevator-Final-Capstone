<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/ping_pong_loader.gif" />
  </div>
  <div id="details" v-else>
    
    <h2 id="name">{{ landmark.landmarkName }}</h2>
    <h4 id="description">{{ landmark.description }}</h4>
    <img v-bind:src="landmark.landmarkImage" alt="">
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
        .getLandmark(this.$route.params.landmarkId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_LANDMARK", response.data);
          this.isLoading = false;
        });
    },
  },
  created() {
    this.retrieveLandmark();
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
  grid-template-columns: 1fr 1fr;
  grid-template-areas: 
  "name name"
  "img description" ;
  
}
img{
  max-width: 500px;
  grid-area: img;
  padding: 15px;
}
#name{
  padding-left: 50px;
  grid-area: name;
}
#description{
  grid-area: description;
  padding: 15px;
}

</style>
