<template>
  <div class="home">
    <h1>Home</h1>
    <p>Welcome to your new home.</p>
    <p>
      In the initial configuration, this page can only be seen when logged in.
    </p>
    <Map/>
  </div>
</template>

<script>
import Map from '../components/Map.vue';
export default {
  name: "home",
  components: {
    Map
  }

  };
</script>
