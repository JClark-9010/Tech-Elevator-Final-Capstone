<template>
  <div>
    <h1>{{ userCoordinates.lat }}</h1>
    <h1>{{ userCoordinates.lng }}</h1>
    <GmapMap id="map"
        :center="{ lat: userCoordinates.lat, lng: userCoordinates.lng }"
        :zoom="10"
        style="width:640px; height:360px; margin: 32px auto;">
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
    };
  },

  created() {
    // get user's userCoordinates from browser request
    this.$getLocation({}).then((userCoordinates) => {
      this.userCoordinates = userCoordinates;
    });
  },
};
</script>
