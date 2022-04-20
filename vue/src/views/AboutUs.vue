<template>
  <div>
    <div class="PatCard" v-on:mouseover="patSip = patProfile">
      <img id="pat" :src="patSip">
      
      <h4>Patrick</h4>
    </div>
    <div class="JasonCard" v-on:mouseover="jasonSip = jasonProfile">
      <img id="jason" :src="jasonSip" >
      <h1>other card</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "aboutUs",
  data(){
    return {
      patSip: require("@/assets/patrick_sip.jpg"),
      patProfile: require("@/assets/patrick_profile.jpg"),
      jasonSip: require("@/assets/jason_sip.jpg"),
      jasonProfile: require("@/assets/jason_profile.jpg")

    }
  }
};
</script>

<style>
.PatCard{
  margin: 20px;
  background-color: #e57d6a;
  border-radius: 10px;
}
#pat{
  width: 150px;
  margin: 7px;
}
.JasonCard{
  margin: 20px;
  background-color: #e57d6a;
  border-radius: 10px;
}
  #jason{
    width: 150px;
    margin: 7px;
  }



</style>