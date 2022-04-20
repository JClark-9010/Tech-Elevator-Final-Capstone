<template>
  <body id="body">
    <h2 id="title">Have you been wanting to see some of the great landmarks in Columbus, Ohio? Well, you've come to the right place.
      Tech Elevator City Tours will help guide you through the great sight-seeing locations in Ohio's capital city. From the amazing animals
      at the world famous Columbus Zoo to the great tastes in the North Market, we want you to see everything Columbus has to offer. Our services 
      are free of charge, just sign up for your personalized account and get started with your itinerary. If you need any assistance, just get with
      one of our travel agents. Enjoy your tour!</h2>
    <div id="landmarks">
      <landmarks-overview/>
    </div>
    <div id="nearMe">
      
    </div>
  </body>
</template>

<script>
import LandmarksOverview from "../components/LandmarksOverview.vue";

export default {
  components: {
    LandmarksOverview,
  },

};
</script>

<style>
#body{
  display: grid;
  grid-template-rows: auto auto;
  grid-template-columns: 1fr 2fr;
  grid-template-areas: 
  "title landmarks"
  "nearMe landmarks"
  ;
 padding-top: 10px;
  padding-right: 10px;
  padding-bottom: 10px;
  padding-left: 10px;

}
#nearMe{
  
  grid-area: nearMe;
  grid-row-gap: 10px;
  grid-column-gap: 40px;
  justify-content: center;
}
#landmarks{
  
  grid-area: landmarks;
}
h2{
  grid-area: title;
  padding-left: 10px;
  padding-top: 15px;
  font-size: 22px;
  justify-content: center;
}
@media all and (max-width: 800px) {
  #body{
    grid-template-areas: 
    "title"
    "nearMe"
    "landmarks";
  }
}

</style>