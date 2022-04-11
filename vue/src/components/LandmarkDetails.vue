<template>
   <div>
       <h1>Hey</h1>
       <table>
      <tbody>
       
        <tr>
            <td>
                {{name}}
            </td>
        </tr>
       
      </tbody>
    </table> </div>
</template>

<script>
export default {
  name: "LandmarkDetail",
  

   

  created() {
    let landmarks = this.$store.state.landmarks;
    this.landmark = landmarks.find((landmark) => {
      return landmark.name == this.landmarkName;
    });
  },
};
</script>

<style>

</style>
