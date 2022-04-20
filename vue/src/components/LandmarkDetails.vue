<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/globe.gif" />
  </div>
  <div id="details" v-else>
    
    <h2 id="name">{{ landmark.landmarkName }}</h2>
    <h4 id="description">{{ landmark.description }}</h4>
    <img id="image" v-bind:src="landmark.landmarkImage" alt="">

    <h1>Visitor Reviews</h1>
    <div id="review" v-for="review in reviews" v-bind:key="review.review">
      <h4>Review Number: {{ review.reviewId }} --- {{ review.description }}</h4>
    </div>

    <div class="container">
      <a
        v-on:click="isFormShown = true"
        v-if="!isFormShown"
        class="btn btn-success"
        >Leave A Review</a
      >

      <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
        <div class="form-group">
          <label for="description">Review: </label>
          <input
            required
            type="textarea"
            id="description"
            name="description"
            class="form-control"
            v-model="newReview.description"
          />
        </div>
        <input type="submit" class="btn btn-success" />
        <input
          type="button"
          v-on:click.prevent="resetForm"
          class="btn btn-success"
          value="Cancel"
        />
      </form>
    </div>

  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService";
import reviewService from "../services/ReviewService";


export default {
  name: "landmark-detail",
  data() {
    return {
      isLoading: true,
      isFormShown: false,
      newReview: {
        landmarkId: this.$store.state.landmark.landmarkId
      }
      
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
    onSubmit(){
          console.log(this.newReview.landmarkId, this.newReview.description)
          reviewService.addReview(this.newReview)
          .then((result) => {
            this.$store.commit("ADD_REVIEW", result.data);
          })
          .then((newResult) => location.reload(newResult));
        }
  },
  created() {
    this.retrieveLandmark();
    this.$store.commit("USER_NOT_IN_ITINERARY");
  },

  computed: {
    landmark() {
      return this.$store.state.landmark;
    },
    reviews() {
      return this.$store.state.reviews;
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
