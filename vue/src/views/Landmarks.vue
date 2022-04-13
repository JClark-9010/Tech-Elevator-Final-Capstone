<template>
  <div> 
      <landmarks-overview />
      <Map/>
  </div>
</template>

<script>
import LandmarksOverview from "../components/LandmarksOverview.vue"
import Map from '../components/Map.vue'

export default {
    name: 'Landmarks',
    components: {
        LandmarksOverview,
        Map
    }
}
</script>

<style>

</style>