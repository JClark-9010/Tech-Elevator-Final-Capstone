<template>
  <body id="body">
    <h2 id="title">This is our homepage</h2>
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
  grid-template-rows: 50px auto;
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