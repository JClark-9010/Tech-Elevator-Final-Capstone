<template>
  <div>
  

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div>
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newLandmark.landmarkName"
        />
      </div>

      <div>
        <label for="zipcode"> Zipcode: </label>
        <input
          type="number"
          id="zipcode"
          name="zipcode"
          class="form-control"
          v-model="newLandmark.zipcode"
        />
      </div>
      <div>
        <label for="type">Description: </label>
        <input
          required
          type="textarea"
          id="description"
          name="type"
          class="form-control"
          v-model="newLandmark.description"
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
</template>

<script>
import landmarksService from "../services/LandmarksService.js";

export default {
    name: "AddLandmark",
    data() {
        return{
            newLandmark: {
            
            },
        }
    },
    methods: {
    onSubmit() {
      this.$store.commit("ADD_LANDMARK", this.newLandmark);

      landmarksService
        .addLandmark(this.newLandmark)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "landmarks" });
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
      this.newLandmark = {};
     
    },
} }
</script>
