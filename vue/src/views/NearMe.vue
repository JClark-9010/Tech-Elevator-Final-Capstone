<template>
  <body id="body">
    <h2 id="title">Thank you for using Tech Elevator City Tours! Check out our local Landmarks and plan your tour!</h2>
    <div id="landmarks">
      <landmarks-overview/>
    </div>
    <div id="nearMe">
      
      <Nearby />
    </div>
  </body>
</template>

<script>
import Nearby from "../components/Nearby.vue";
import LandmarksOverview from "../components/LandmarksOverview.vue";

export default {
  components: {
    Nearby,
    LandmarksOverview,
  },

};
</script>

<style>
#body{
  display: grid;
  grid-template-rows: 50px 300px auto;
  grid-template-columns: 1fr;
  
  grid-template-areas: 
  "title"
  "nearMe"
  "landmarks"
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
  margin-left: 200px;
  margin-right:200px;
}
#landmarks{
  
  grid-area: landmarks;
}
h2{
  grid-area: title;
  padding-left: 10px;
  padding-top: 15px;
  font-size: 22px;
}
@media all and (max-width: 800px) {
  #body{
    grid-template-areas: 
    "title"
    "nearMe"
    "landmarks";
  }
  nearMe{
    margin-left: 10px;
    margin-right: 10px;
  }
}

</style>