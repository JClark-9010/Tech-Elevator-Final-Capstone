<template>
  <div id="homediv">
    <h2 id="title">Have you been wanting to see some of the great landmarks in Columbus, Ohio? Well, you've come to the right place.
      Tech Elevator City Tours will help guide you through the great sight-seeing locations in Ohio's capital city. From the amazing animals
      at the world famous Columbus Zoo to the great tastes in the North Market, we want you to see everything Columbus has to offer. Our services 
      are free of charge, just sign up for your personalized account and get started with your itinerary. If you need any assistance, just get with
      one of our travel agents. Enjoy your tour!</h2>
    <img id="sqrLogo" src="@/assets/TeamJuliettLogo.png" alt="">
    
  </div>
</template>

<script>


export default {
  components: {
    
  },

};
</script>

<style>
#homediv{
  display: flex;
  
  flex-direction: column;
  
  justify-content: center;
  align-items: center;
  margin: 15px;
}
#title{
  
}
#sqrLogo{
  width: 500px;
}
@media all and (max-width: 800px) {
  #div{
    
  }
}

</style>