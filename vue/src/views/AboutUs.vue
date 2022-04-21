<template>
  <div>
    <div
      class="aboutCard" id="pats"
      v-on:mouseenter="patPhoto = patSip"
      v-on:mouseleave="patPhoto = patProfile"
    >
      <img id="pat" :src="patPhoto" />
      <h4 id="us">Patrick Dewey</h4>
      <p id="usPara">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
        occaecat cupidatat non proident, sunt in culpa qui officia deserunt
        mollit anim id est laborum.
      </p>
    </div>
    <div
      class="aboutCard" id="jasons"
      v-on:mouseenter="jasonPhoto = jasonSip"
      v-on:mouseleave="jasonPhoto = jasonProfile"
    >
      <img id="jason" :src="jasonPhoto" />

      <h4 id="us">Jason Clark</h4>
      <p id="usPara">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
        occaecat cupidatat non proident, sunt in culpa qui officia deserunt
        mollit anim id est laborum.
      </p>
    </div>
    <div
      class="aboutCard" id="awels"
      v-on:mouseenter="awelPhoto = awelSip"
      v-on:mouseleave="awelPhoto = awelProfile"
    >
      <img id="awel" :src="awelPhoto" />

      <h4 id="us">Awel Alin</h4>
      <p id="usPara">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
        occaecat cupidatat non proident, sunt in culpa qui officia deserunt
        mollit anim id est laborum.
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "aboutUs",
  data() {
    return {
      patPhoto: require("@/assets/patrick_profile.jpg"),
      patSip: require("@/assets/patrick_sip.jpg"),
      patProfile: require("@/assets/patrick_profile.jpg"),
      jasonPhoto: require("@/assets/jason_profile.jpg"),
      jasonSip: require("@/assets/jason_sip.jpg"),
      jasonProfile: require("@/assets/jason_profile.jpg"),
      awelPhoto: require("@/assets/awel_profile.jpg"),
      awelSip: require("@/assets/awel_sip.jpg"),
      awelProfile: require("@/assets/awel_profile.jpg"),
    };
  },
};
</script>

<style>
#jasons{
  background-color: #208B77;
}
#awels{
  background-color: #1a5270;
}
.aboutCard {
  margin: 20px;
  margin-right: 200px;
  margin-top: 30px;
  margin-right: 200px;
  background-color: #e57d6a;
  border-radius: 10px;
  display: grid;
  grid-template-columns: 200px auto;
  grid-template-rows: 50px auto;
  grid-template-areas: 
  "h4 h4"
  "img para";

}
img {
  grid-area: img;
}
#us {
  grid-area: h4;
  padding: 8px;
  padding-left: 15px;
  padding-top: 10px;
  color: #ead6c7;
}
#usPara{
  grid-area: para;
  font-size: 18px;
  color: #ead6c7;
  padding-right: 10px;
}
#pat {
  width: 170px;
  margin: 7px;
  padding: 8px;
}

#jason {
  padding: 8px;
  width: 170px;
  margin: 7px;
}
#awel {
  padding: 8px;
  width: 170px;
  margin: 7px;
}
</style>