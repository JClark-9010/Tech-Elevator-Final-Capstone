<template>
  <div id="app">
    <h2>Routes Google Maps</h2>
    <div>
      <table>
        <tr>
          <th>Start Location</th>
          <th><GmapAutocomplete @place_changed="setPlace" /></th>
          <th style="width: 50%">
            <button class="btn" @click="addMarker(0)">Add</button>
          </th>
        </tr>
        <tr>
          <th>End Location</th>
          <th><GmapAutocomplete @place_changed="setPlace" /></th>
          <th style="width: 50%">
            <button class="btn" @click="addMarker(1)">Add</button>
          </th>
        </tr>
      </table>
    </div>
    <br />
    <GmapMap
      :zoom="7"
      :center="userCoordinates"
      style="width: 50%; height: 400px"
    >
      <DirectionsRenderer
        travelMode="DRIVING"
        :origin="startLocation"
        :destination="endLocation"
      />

      <gmap-marker
        :key="index"
        v-for="(landmark, index) in landmarks"
        :position="{
          lat: parseFloat(landmark.landmarkLat),
          lng: parseFloat(landmark.landmarkLng),
        }"
        :clickable="true"
        :draggable="false"
        :icon="markerOptions"
      ></gmap-marker>
    </GmapMap>
  </div>
</template>
<script >
import DirectionsRenderer from "../services/DirectionsRenderer.js";


export default {
  name: "App",
  components: {
    DirectionsRenderer, 
  },
  data() {
    return {
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      currentPlace: null,
      markers: [],
      places: [],
      startLocation: null,
      endLocation: null,
    };
  },

  created() {
    // does the user have a saved center? use it instead of the default
    if (localStorage.center) {
      this.userCoordinates = JSON.parse(localStorage.center);
    } else {
      // get user's coordinates from browser request
      this.$getLocation({})
        .then((coordinates) => {
          this.userCoordinates = coordinates;
        })
        .catch((error) => alert(error));
    }
    // does the user have a saved zoom? use it instead of the default
    if (localStorage.zoom) {
      this.zoom = parseInt(localStorage.zoom);
    }
    this.routingService = this.platform.getRoutingService();
  },

 mounted() {
    // add the map to a data object
    this.$refs.mapRef.$mapPromise.then((map) => (this.map = map));
  },


  methods: {
    setPlace(place) {
      this.currentPlace = place;
    },
    addMarker(index) {
      const marker = {
        lat: this.currentPlace.geometry.location.lat(),
        lng: this.currentPlace.geometry.location.lng(),
      };
      if (index === 0) this.startLocation = marker;
      if (index === 1) this.endLocation = marker;
      this.center = marker;
    },
  },


 computed: {
    mapCoordinates() {
      if (!this.map) {
        return {
          lat: 0,
          lng: 0,
        };
      }
      return {
        lat: this.map.getCenter().lat().toFixed(4),
        lng: this.map.getCenter().lng().toFixed(4),
      };
    },
    landmarks() {
      return this.$store.state.landmarks;
    },
  },



};
</script>
