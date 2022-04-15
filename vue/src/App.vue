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
      <router-link id="bar" v-bind:to="{ name: 'itinerary'}" v-if="$store.state.user.role == 'user'">Itinerary</router-link>

    </div>
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
 
}

h1{
  font-family:Arial, Helvetica, sans-serif;
  text-shadow: 1px 1px gray;
}
#nav{
  
  

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




</style>