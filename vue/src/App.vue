<template>
  <div id="app">
    <header>
      <h1>Tech Elevator City Tours</h1>
    <div id="nav">
      <router-link id="bar" v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link id="bar" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link> 
      <!-- <router-link id="bar" v-bind:to="{ name: 'landmarks' }">Landmarks</router-link>  -->
      <router-link id="bar" v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'admin'">Add Landmark</router-link>
      <router-link id="bar" v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'user'">Suggest Landmark</router-link> 
      <router-link id="bar" v-bind:to="{ name: 'nearMe'}" >Landmarks Near Me</router-link> 
      <router-link id="bar" v-bind:to="{ name: 'my-itineraries'}" v-if="$store.state.user.role == 'user'">My Itineraries</router-link>
      <router-link id="bar" v-bind:to="{ name: 'create-itinerary'}" v-if="$store.state.user.role == 'user'">Create New Itinerary</router-link>

    </div>
    <img id="skyline" src="https://www.columbusddc.com/assets/inc/timthumb.php?src=https://03f59d67b8953209fecb-2ffae5b4d8c8fad2d75b1377df2d5b7c.ssl.cf2.rackcdn.com/banner-Scioto-Mile-Banner-2.png&w=2000&h=560&zc=1" alt="">
    </header>
    <router-view />
    <p>Built By DewelOn Llc.</p>
  </div>
</template>

<style>
body{
  background-color: rgb(226, 224, 224);
  
}
header{
  background-color: #41cff7;
  padding-top: 10px;
  padding-right: 10px;
  padding-bottom: 10px;
  padding-left: 10px;
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: 
  "h1 skyline"
  "nav skyline";
}

h1{
  font-family:Arial, Helvetica, sans-serif;
  text-shadow: 1px 1px gray;
  grid-area: h1;
}
#nav{
  grid-area: nav;
  

}
#bar{
  color: black;
  padding-left: 5px;
  padding-right: 5px;
  border: black;
  border-style: solid;
  margin-right: 10px;
  background-color: rgb(12, 204, 211);
  border-width: .5px;
  border-radius: 4px ;
  text-align: center;
  box-shadow: 1.5px 1.5px 1.5px gray;
}
#skyline{
  grid-area: skyline;
  max-height: 90px;
}




</style>