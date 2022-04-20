import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import VueGeolocation from 'vue-browser-geolocation'

Vue.config.productionTip = false
Vue.use(VueGeolocation)

import * as VueGoogleMaps from 'vue2-google-maps'
Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCkWf-D9gucrZJ0RQKcH49mm6fJHnCtzr0',
<<<<<<< HEAD
    libraries: 'places',
=======
>>>>>>> c4c45df3ce9be00dca42e1083cc4028b098416d9
  },
})




axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

<<<<<<< HEAD

import { MapElementFactory } from "vue2-google-maps";
Vue.use(MapElementFactory, {
  load: {
    key: 'AIzaSyCkWf-D9gucrZJ0RQKcH49mm6fJHnCtzr0',
    libraries: 'places',
  },
})
=======
>>>>>>> c4c45df3ce9be00dca42e1083cc4028b098416d9
