<template>
  <div>
    <div
      style="
        max-width: 100px;
        margin: 0 auto;
        display: flex;
        align-items: center;
        justify-content: space-between;
      "
    >
      <!-- <div>
        <h1>Your coordinates:</h1>
        <p>
          {{ userCoordinates.lat }} Latitude,
          {{ userCoordinates.lng }} Longitude
        </p>
      </div>
      <div>
        <h1>Map coordinates:</h1>
        <p>
          {{ mapCoordinates.lat }} Latitude, {{ mapCoordinates.lng }} Longitude
        </p>
      </div> -->
    </div>
    <GmapMap
      :center="userCoordinates"
      :zoom="zoom"
      style="width: 700px; height: 250px; margin: 32px auto; border-color: #208B77; border-style: solid;
   box-shadow: 2px 2px gray; justify-content: center;"
      ref="mapRef"
      @dragend="handleDrag"
    >
      <gmap-marker
        :key="index"
        v-for="(landmark, index) in landmarks"
        :position="{
          lat: parseFloat(landmark.landmarkLat),
          lng: parseFloat(landmark.landmarkLng),
        }"
        :clickable="true"
        :draggable="false"
      ></gmap-marker>
    </GmapMap>
  </div>
</template>

<script>
export default {
  data() {
    return {
      map: null,
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      zoom: 7,
      lat: [],
      lng: [],
      routingService: {},
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
  },

  mounted() {
    // add the map to a data object
    this.$refs.mapRef.$mapPromise.then((map) => (this.map = map));
  },
  methods: {
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
    displayRoute(userCoordinates, mapCoordinates) {
      this.routingService.calculateRoute (
          {
                "mode": "fastest;car;traffic:enabled",
                "waypoint1": `${userCoordinates.lat},${userCoordinates.lng}`,
                 "waypoint2": `${mapCoordinates.lat},${mapCoordinates.lng}`,
                 "representation": "display",

          },
          data => {
            console.log(data);
          },
          error => {
            console.error(error);
          }
          
      );
    }
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

<style>

</style>