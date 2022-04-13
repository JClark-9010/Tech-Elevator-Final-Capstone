<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'landmarks' }">Landmarks</router-link> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'admin'">Add Landmark</router-link>
      <!-- <router-link v-bind:to="{ name: 'addLandmark'}" v-if="$store.state.user.role == 'user'">Suggest Landmark</router-link> &nbsp;|&nbsp; -->
      <router-link v-bind:to="{ name: 'nearMe'}" v-if="$store.state.user.role == 'user'">Landmarks Near Me</router-link>
    </div>
    <router-view />
  </div>
</template>
