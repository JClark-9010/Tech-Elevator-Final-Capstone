<template>
  <div id="genRoute">
    <h2>Routes Google Maps</h2>
    <div>
      <table>
        <tr>
          <th>Start</th>
          <th><GmapAutocomplete @place_changed="setPlace" /></th>
          <th style="width: 50%">
            <button class="btn" @click="addMarker(0)">Add</button>
          </th>
        </tr>
        <tr>
          <th>End</th>
          <th><GmapAutocomplete @place_changed="setPlace" /></th>
          <th style="width: 50%">
            <button class="btn" @click="addMarker(1)">Add</button>
          </th>
        </tr>
      </table>
    </div>
    <br />
    <GmapMap
      :center="userCoordinates"
      :zoom="7"
      style="width: 700px; height: 350px; margin: 32px auto; border-color: #208B77; border-style: solid;
   box-shadow: 2px 2px gray;"
      @dragend="handleDrag"
      ref="mapRef"
    >
      <DirectionsRenderer
        travelMode="DRIVING"
        :origin="userCoordinates"
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
<script>
import DirectionsRenderer from "@/components/DirectionsRenderer";
export default {
  name: "directions",
  components: {
    DirectionsRenderer,
  },
  data() {
    return {
      center: {},
      currentPlace: null,
      markers: [],
      places: [],
      startLocation: null,
      endLocation: null,
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      lat: [],
      lng: [],
      routingService: {},
    };
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
    handleDrag() {
      // get center and zoom level, store in localstorage
      let center = {
        lat: this.map.getCenter().lat(),
        lng: this.map.getCenter().lng(),
      };
      let zoom = this.map.getZoom();
      localStorage.center = JSON.stringify(center);
      localStorage.zoom = zoom;
    },
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
};
</script>
<style>
#genRoute {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.pac-target-input {
  padding: 10px;
  width: 100%;
}
.btn {
  margin-left: 20px;
  padding: 10px 20px;
  background-color: greenyellow;
}
</style>