<template>
  <div>
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
import reviewService from "../services/ReviewService";
export default {
  name: "reviews",
  data() {
    return {
      isLoading: true,
      isFormShown: false,
      newReview: {
        landmarkId: this.$route.params.landmarkId,
      },
    };
  },
    methods: {
        onSubmit(){
          console.log(this.newReview.landmarkId, this.newReview.description)
          reviewService.addReview(this.newReview)
          .the((result) => {
            this.$store.commit("ADD_REVIEW", result.data);
          })
          .then((newResult) => location.reload(newResult));
        }
    },
  computed: {
    reviews() {
      return this.$store.state.reviews;
    },
    // landmarkId() {
    //   return this.$store.state.landmark.landmarkId;
    // },
  },
};
</script>

<style>
</style>