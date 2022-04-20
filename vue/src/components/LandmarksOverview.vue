<template>
  <div>
    <label for="radius">Select Filter Radius</label>

    <select v-model="radius" name="radius" id="radius">
      <option value="1000" selected>Show All</option>
      <option value="1">1mile</option>
      <option value="2">2miles</option>
      <option value="5">5miles</option>
      <option value="10">10miles</option>
      <option value="20">20miles</option>
    </select>
    <div id="overview">
      <div
        id="landmarkCard"
        v-for="landmark in sortLandmarks"
        v-bind:key="landmark.landmarkId"
      >
        <h5 v-on:click="viewLandmarkDetails(landmark.landmarkId)">
          {{ landmark.landmarkName }}
        </h5>
        <!-- <td>{{ landmark.landmarkLat }}</td>
          <td>{{ landmark.landmarkLng }}</td> -->
        <p id="distance">
          {{
            distance(
              userCoordinates.lat,
              userCoordinates.lng,
              landmark.landmarkLat,
              landmark.landmarkLng
            ).toFixed(2)
          }}miles from You
        </p>
        <img
          id="detImage"
          v-bind:src="landmark.landmarkImage"
          alt=""
          v-on:click="viewLandmarkDetails(landmark.landmarkId)"
        />
        <!-- <button v-else>Add Landmark to Itinerary></button> -->
        <button
          v-if="inItinerary"
          v-on:click="addLandmarkToItinerary(landmark.landmarkId)"
        >
          Add Landmark to Itinerary
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
import itineraryService from "../services/ItineraryService.js";
import reviewService from "../services/ReviewService.js";
export default {
  name: "LandmarksOverview",
  data() {
    return {
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      radius: 1000,
    };
  },
  methods: {
    viewLandmarkDetails(landmarkId) {
      reviewService.getReviews(landmarkId).then((response) => {
        this.$store.commit("GET_REVIEWS", response.data);
      })
      this.$router.push(`/landmarks/${landmarkId}`);
    },

    addLandmarkToItinerary(landmarkId) {
      console.log(this.itineraryId, landmarkId, this.$store.state.user.userId);
      itineraryService.addLandmarkToItinerary(
        this.itineraryId,
        landmarkId,
        this.$store.state.user.userId
      );
      itineraryService
        .getItinerary(this.itineraryId)
        .then((response) => {
          this.$store.commit("SET_CURRENT_ITINERARY", response.data);
        })
        .then((newResult) => location.reload(newResult));
    },

    distance(lat1, lng1, lat2, lng2) {
      const R = 3958.8;
      let dLat = this.deg2rad(lat2 - lat1);
      let dLng = this.deg2rad(lng1 - lng2);
      let a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(this.deg2rad(lat1)) *
          Math.cos(this.deg2rad(lat2)) *
          Math.sin(dLng / 2) *
          Math.sin(dLng / 2);
      let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
      let d = R * c;
      return d;
    },
    deg2rad(deg) {
      return deg * (Math.PI / 180);
    },
    
  },
  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    inItinerary() {
      return this.$store.state.inItinerary;
    },
    itineraryDetails() {
      return this.$store.state.itineraryDetails;
    },
    filterLandmarks() {
      let filterLandmarks = this.$store.state.landmarks.slice();
      return filterLandmarks.filter(
        (landmark) =>
          this.distance(
            this.userCoordinates.lat,
            this.userCoordinates.lng,
            landmark.landmarkLat,
            landmark.landmarkLng
          ) < this.radius
      );
    },
    sortLandmarks() {
      let sortedLandmarks = this.filterLandmarks;
      return sortedLandmarks.sort((a, b) => {
        return (
          this.distance(
            this.userCoordinates.lat,
            this.userCoordinates.lng,
            a.landmarkLat,
            a.landmarkLng
          ) -
          this.distance(
            this.userCoordinates.lat,
            this.userCoordinates.lng,
            b.landmarkLat,
            b.landmarkLng
          )
        );
      });
    },
    itineraryId() {
      return this.$store.state.itinerary.itineraryId;
    },
  },
  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
    });
    this.$getLocation({})
      .then((coordinates) => {
        this.userCoordinates = coordinates;
      })
      .catch((error) => alert(error));
  },
};
</script>

<style>
#overview {
  display: flex;
  flex-wrap: wrap;
  padding-left: 25px;
}
label {
  color: #1a5270;
  padding-left: 55px;
  padding-right: 10px;
}
#radius {
  
  height: 25px;
  background-color: #1a5270;
  color: #ead6c7;
}
#landmarkCard {
  /* border-style: solid; */
  border-color: black;
  padding-left: 25px;
  padding-right: 25px;
  padding-top: 5px;
  border-radius: 20px;
  display: grid;
  flex-wrap: wrap;
  color: #ead6c7;

  grid-template-columns: 210px;
  grid-template-rows: 175px 85px 20px 70px;
  grid-template-areas:
    "img"
    "h5"
    "distance"
    "button";

  margin: 20px;
  background-color: #e57d6a;
}
#landmarkCard:hover {
  background-color: #1a5270;
}
#distance {
  grid-area: distance;
  text-align: center;
}
h5 {
  grid-area: h5;
  text-align: center;
  margin-top: 15px;
}
p {
  grid-area: para;
  font-size: 12px;
}
#detImage {
  width: 210px;
  /* max-height: 175px; */
  grid-area: img;
  margin-top: 10px;
}
#detImage:hover {
  border: #ead6c7;
  border-style: solid;
  border-radius: 6px;
}
button {
  background-color: #208B77;
  height: 50px;
  justify-content: center;
  grid-area: button;
  border: black;
  border-radius: 5px;
  color: #ead6c7;
}
button:hover {
  border: #ead6c7;
  border-style: solid;
  border-radius: 6px;
}
</style>