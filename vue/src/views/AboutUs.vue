<template>
  <div>
    <h2>DewelOn Llc was forged in the fires of John Fultons 4-5 hour lectures</h2>
    <div
      class="aboutCard"
      id="pats"
      v-on:mouseenter="patPhoto = patSip"
      v-on:mouseleave="patPhoto = patProfile"
    >
      <img id="pat" :src="patPhoto" />
      <h4 id="us">Patrick Dewey</h4>
      <p id="usPara">
        Hi I'm Patrick, I'm trying to find my first job as a software developer.
        I have always been a sort of jack-of-all-trades in my past careers, due
        to my strong work ethic and dependability. At every job I've had I was
        singled out to take on more responsibility and learn new skills. In my
        last job at a small brewery I started out as a bartender and was
        promoted a full time brewing asst, canning line operator and I was the
        companys first salesperson. I am excited to continue learning more about
        programing and technology. I'm looking forward to the opportunity to
        learn along with your team.
      </p>
    </div>
    <div
      class="aboutCard"
      id="jasons"
      v-on:mouseenter="jasonPhoto = jasonSip"
      v-on:mouseleave="jasonPhoto = jasonProfile"
    >
      <img id="jason" :src="jasonPhoto" />

      <h4 id="us">Jason Clark</h4>
      <p id="usPara">
        Hi, I'm Jason Clark. I'm an army veteran and I used the experience and
        training I gained in the military to keep this team in line. I came to
        Tech Elevator because computer programming excites me and I see a career
        in software develpment as a way to best apply my strengths in a field
        that I'm passionate about. I'm a problem solver and I'm a team player,
        and I'm looking to bring those qualities and my skills to a company as a
        junior software developer.
      </p>
    </div>
    <div
      class="aboutCard"
      id="awels"
      v-on:mouseenter="awelPhoto = awelSip"
      v-on:mouseleave="awelPhoto = awelProfile"
    >
      <img id="awel" :src="awelPhoto" />

      <h4 id="us">Awel Alin</h4>
      <p id="usPara">
        Hello, my name is Awel Alin and I've always had a passion for helping
        people through their problems and circumstances. This is something that
        I utilized in my career in the non-profit sector, most recently at the
        Red Cross, by helping individuals and families who were displaced by
        natural dictators. Now, I'm looking to use my passion for problem
        solving and apply it to the Tech Industry. I'm looking to apply to a
        role as a junior Software Engineer where I can continue to learn and
        grow in my new career.
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "aboutUs",
  data() {
    return {
      patPhoto: require("@/assets/patrick_profile.jpg"),
      patSip: require("@/assets/patrick_sip.jpg"),
      patProfile: require("@/assets/patrick_profile.jpg"),
      jasonPhoto: require("@/assets/jason_profile.jpg"),
      jasonSip: require("@/assets/jason_sip.jpg"),
      jasonProfile: require("@/assets/jason_profile.jpg"),
      awelPhoto: require("@/assets/awel_profile.jpg"),
      awelSip: require("@/assets/awel_sip.jpg"),
      awelProfile: require("@/assets/awel_profile.jpg"),
    };
  },
};
</script>

<style>
#jasons {
  background-color: #208b77;
}
#awels {
  background-color: #1a5270;
}
.aboutCard {
  margin: 20px;
  margin-right: 200px;
  margin-top: 30px;
  margin-right: 200px;
  background-color: #e57d6a;
  border-radius: 10px;
  display: grid;
  grid-template-columns: 200px auto;
  grid-template-rows: 50px auto;
  grid-template-areas:
    "h4 h4"
    "img para";
}
img {
  grid-area: img;
}
#us {
  grid-area: h4;
  padding: 8px;
  padding-left: 15px;
  padding-top: 10px;
  color: #ead6c7;
}
#usPara {
  grid-area: para;
  font-size: 18px;
  color: #ead6c7;
  padding-right: 10px;
}
#pat {
  width: 170px;
  margin: 7px;
  padding: 8px;
}

#jason {
  padding: 8px;
  width: 170px;
  margin: 7px;
}
#awel {
  padding: 8px;
  width: 170px;
  margin: 7px;
}
</style>