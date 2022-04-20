<template>
<div>

  <div class="loading" v-if="isLoading">
    <img src="../assets/globe.gif" />
  </div>
  <div id="details" v-else>
    <h1 id="name">{{ landmark.landmarkName }}</h1>
    <h4 id="description">{{ landmark.description }}</h4>
    <img id="image" v-bind:src="landmark.landmarkImage" alt="" />
  </div>

    <h2 id="revHeader">Visitor Reviews</h2>
    <div id="reviews" v-for="review in reviews" v-bind:key="review.review">
      <h5 id="reviewNum">Review Number: {{ review.reviewId }}</h5>
      <h5 id="review">{{ review.description }}</h5>
    </div>

    <div class="reviewForm">
      <button id="leaveReview"
        v-on:click="isFormShown = true"
        v-if="!isFormShown"
       
        >Leave A Review</button
      >

      <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
        <div class="form-group">
          <label for="description">Review: </label>
          <input
            required
            type="textarea"
            id="inputReview"
            name="description"
            class="form-control"
            v-model="newReview.description"
          />
        </div>
        <input type="submit" id="submit" />
        <input
          type="button"
          v-on:click.prevent="resetForm"
          id="cancel"
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
        landmarkId: parseInt(this.$route.params.landmarkId),
      },
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
    onSubmit() {
      console.log(this.newReview.landmarkId, this.newReview.description);
      reviewService.addReview(this.newReview).then((response) => {
        this.$store.commit("ADD_REVIEW", response.data)
      });
      this.resetForm();
    },
    resetForm() {
      this.newReview = {};
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
    reviews() {
      return this.$store.state.reviews;
    },
  },
};
</script>

<style>
#details {
  display: grid;
  grid-template-rows: 80px 300px;
  grid-template-columns: 1fr 2fr;
  grid-template-areas:
    "name name"
    "img description";
}
h1 {
  padding-top: 10px;
  font-style: bold;
  color: #1a5270;
}
#image {
  max-width: 500px;
  grid-area: img;
  padding-left: 40px;
}
#name {
  padding-left: 40px;
  grid-area: name;
  justify-content: center;
}
#description {
  grid-area: description;
  color: #ead6c7;
  
  margin-left: 20px;
  margin-right: 20px;
  padding: 15px;
  border-style: solid;
  font-size: 22px;
  border-radius: 10px;
  background-color: #1a5270;
}
#revHeader{
  margin-left: 29px;
  margin-top: 10px;
}
#reviews{
  padding-left: 20px;
  display: grid;
  grid-template-columns: 800px;
  grid-template-rows: 47px auto;
  grid-template-areas: 
  "num "
  "review";
  background-color: #e57d6a;
  
  border-radius: 5px;
  
  margin-right: 380px;
  margin-bottom: 10px;
  margin-left: 50px;
}
#reviewNum{
  grid-area: num;
  text-align: left;
  color:#1a5270;
  font-size: 23px;
}
#review{
  color:#1a5270;
  grid-area: review;
  text-align: left;
  padding-left: 8px;
}
#leaveReview{
  margin-left: 29px;
  background-color: #208B77;
  height: 50px;
  justify-content: center;
  grid-area: button;
  border: black;
  border-radius: 5px;
  color: #ead6c7;
  }
#leaveReview:hover{
  border: #ead6c7;
  border-style: solid;
  border-radius: 6px;
}
#inputReview{
  width: 835px;
  
  margin-left: 50px;
}
#submit{
  margin-left:29px;
}
#submit, #cancel{
  margin-right: 4px;
  background-color: #208B77;
  height: 40px;
  justify-content: center;
  grid-area: button;
  border: black;
  border-radius: 5px;
  color: #ead6c7;
}
#submit:hover, #cancel:hover {
  border: #ead6c7;
  border-style: solid;
  border-radius: 6px;
 
}

</style>
