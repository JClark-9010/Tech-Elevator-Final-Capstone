<template>
  <div>

    <h3>Submit New Landmark</h3>

    <add-landmark />
  </div>
</template>

<script>
import AddLandmark from "../components/AddLandmark.vue";
export default {
  components: { AddLandmark },
};
</script>

<style>
h3{
  padding-left: 10px;
}
</style> 