import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import VueGeolocation from 'vue-browser-geolocation'
import GmapCustomMarker from 'vue2-gmap-custom-marker'

Vue.config.productionTip = false
Vue.use(VueGeolocation, GmapCustomMarker)

import * as VueGoogleMaps from 'vue2-google-maps'
Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCkWf-D9gucrZJ0RQKcH49mm6fJHnCtzr0',
  },
})


axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

