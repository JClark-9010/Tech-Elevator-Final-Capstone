<template>
  <div>
    <Map /> 
    <div id="closest">

      <h4>The Closest Landmark to You is..</h4>
        <h3>{{closest(landmarks, userCoordinates)}}</h3>
        <p>placed at 8:51pm 4/14/2011</p>
        <p>how long did it take you to find this</p>
    </div>
     <!-- <table>
      <tbody>
        <tr v-for="landmark in landmarks" v-bind:key="landmark.landmarkId">
          <td >
            {{ landmark.landmarkName }}
          </td>
          <td>{{distance( userCoordinates.lat, userCoordinates.lng, landmark.landmarkLat, landmark.landmarkLng)}}</td>
        </tr>
      </tbody>
    </table> -->
    
 </div>
  

 
</template>

<script>
import landmarksService from "../services/LandmarksService.js";
import Map from "../components/Map.vue";





export default {
  name: "nearby",
  data() {
    return {
      
      userCoordinates: {
        lat: 0,
        lng: 0,
      },
      
    };
  },
  

  components: {
    Map,
  },
  
  //returning landmarks with certain radius or closest landmark
  //

  computed: {
    landmarks() {
      return this.$store.state.landmarks;
    },
    
  },
  methods:{
    viewLandmarkDetails(landmarkId) {
      this.$router.push(`/landmarks/${landmarkId}`);
    },
    
    closest(landmarks, userCoordinates){
      let nearLandmark = 0;
       landmarks.forEach(  (landmark) => {
        if (this.distance(userCoordinates.lat, userCoordinates.lng, landmark.landmarkLat, landmark.landmarkLng) < 6.3){
          nearLandmark = landmark;
        }
      });
      
      return nearLandmark.landmarkName;
    },
    distance(lat1, lng1, lat2, lng2) {
      const R = 3958.8;
      let dLat = this.deg2rad(lat2 - lat1);
      let dLng = this.deg2rad(lng1 - lng2);
      let a =
          Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(this.deg2rad(lat1)) *
          Math.cos(this.deg2rad(lat2)) *
          Math.sin(dLng / 2) *
          Math.sin(dLng / 2);
      let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
      let d = R * c;
      return d;
    },
    deg2rad(deg) {
      return deg * (Math.PI / 180);
    },

  },
  created() {
    landmarksService.getLandmarks().then((response) => {
      this.$store.commit("REPLACE_LANDMARKS", response.data);
      if (localStorage.center) {
      this.userCoordinates = JSON.parse(localStorage.center);
    } else {
      // get user's coordinates from browser request
      this.$getLocation({})
        .then((coordinates) => {
          this.userCoordinates = coordinates;
        })
        .catch((error) => alert(error));
    }
    // does the user have a saved zoom? use it instead of the default
    if (localStorage.zoom) {
      this.zoom = parseInt(localStorage.zoom);
    }
    });
  
  },
};
</script>

<style>

#closest{
  text-align: center;
}

</style>