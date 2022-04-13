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
        <label for="lat"> Latitude: </label>
        <input
          type="text"
          id="lat"
          name="lat"
          class="form-control"
          v-model="landmark.lat"
        />
      </div>
      <div>
        <label for="lng"> Longitude: </label>
        <input
          type="text"
          id="lng"
          name="lng"
          class="form-control"
          v-model="landmark.lng"
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
