<template>
  <div>
      <h1>Visitor Reviews</h1>
      <div id="review" v-for="review in reviews" v-bind:key="review.review">

        <h4>Review Number: {{review.reviewId}} --- {{ review.description }} </h4>
      </div>
  </div>
</template>

<script>
// import reviewService from "../services/reviewService";
export default {
    name: "reviews",
  data() {
    return {
      isLoading: true,
    };
  },
//   methods: {
//       getReviews(){

//       }
//   },
  computed: {
    reviews() {
      return this.$store.state.reviews;
    },

  },
}
</script>

<style>

</style>