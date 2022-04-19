<template>
  <div>
    <div class="card">
      <img id="profile" src="@/assets/patrick_sip.jpg" alt="Card Back" />
      <img id="profile" src="@/assets/patrick_profile.jpg" class="img-top" alt="Card Front" />
    </div>
  </div>
</template>

<script>
export default {
  name: "aboutUs",
};
</script>

<style>
.card {
  width: 130px;
  height: 195px;
  position: relative;
  display: inline-block;
  background-color: #1A5270;
}
#profile{
    width: 150px;
}
.card .img-top {
  display: none;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 99;
}
.card:hover .img-top {
  display: inline;
}
</style>