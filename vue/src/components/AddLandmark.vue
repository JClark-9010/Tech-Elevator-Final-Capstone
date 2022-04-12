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
          v-model="landmark.landmarkName"
        />
      </div>

      <div>
        <label for="zipcode"> Zipcode: </label>
        <input
          type="number"
          id="zipcode"
          name="zipcode"
          class="form-control"
          v-model.number="landmark.zipcode"
        />
      </div>
      <div>
        <label for="description">Description: </label>
        <input
          required
          type="textarea"
          id="description"
          name="description"
          class="form-control"
          v-model="landmark.description"
        />
      </div>

      <input type="submit" />
      <input type="button" v-on:click.prevent="resetForm" value="Cancel" />
    </form>
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";

export default {
  name: "add-landmark",
  data() {
    return {
      landmark: {},
    };
  },
  methods: {
    onSubmit() {
      
      this.$store.commit("ADD_LANDMARK", this.landmark);

      landmarksService
        .addLandmark(this.landmark)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({name: "Landmarks"});
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
      this.landmark = {};
    },

    created() {}
  },
};
</script>
