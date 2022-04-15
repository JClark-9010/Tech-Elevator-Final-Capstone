<template>
  <div id="app">
    <header>
      <h1>Tech Elevator City Tours</h1>
    <div id="nav">
      <router-link id="home" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'landmarks' }">Landmarks</router-link> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'admin'">Add Landmark</router-link>
      <router-link v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'user'">Suggest Landmark</router-link> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'nearMe'}" v-if="$store.state.user.role == 'user'">Landmarks Near Me</router-link>
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
  border: black;
  border-style: solid;

}





</style>