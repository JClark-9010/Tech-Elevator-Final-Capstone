<template>
  <div v-if="responseAvailable == true">
    <p>{{ result }}</p>
  </div>
</template>

<script src="http://api.postionsstack.com/v1/forward">
export default {
  name: "distance",
  data() {
    return {
      result: "",
      responseAvailable: false,
      apiKey: "9fa54e38aa5a087b9f95f34a1b853b14",
    };
  },
  methods: {
    fetchAPIData() {},
  },
};
</script>

<style>
</style>