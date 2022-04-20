<template>
  <div>
    <itineraries />
    <generate-route />
    
  </div>
</template>

<script>
import GenerateRoute from '../components/GenerateRoute.vue';


import Itineraries from "../components/Itineraries.vue";
export default {
  components: { Itineraries, GenerateRoute},
  data() {
    return
    
  },
};
</script>

<style>
</style>