<template>
  <section class="vh-100">
    <div class="container h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-lg-12 col-xl-11">
          <div class="card text-black" style="border-radius: 25px">
            <div class="card-body p-md-5">
              <div class="row justify-content-center">
                <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">
                  <form class="form-signin" @submit.prevent="login">
                    
                    <h2 class="h3 mb-3 font-weight-normal">Please Sign In</h2>
                    <div
                      class="alert alert-danger"
                      role="alert"
                      v-if="invalidCredentials"
                    >
                      Invalid username and password!
                    </div>
                    <div
                      class="alert alert-success"
                      role="alert"
                      v-if="this.$route.query.registration"
                    >
                      Thank you for registering, please sign in.
                    </div>

                    <div class="d-flex flex-row align-items-center mb-4">
                      <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                      <div class="form-outline flex-fill mb-0">
                        <label for="username" class="sr-only">Username</label>
                        <input
                          type="text"
                          id="username"
                          class="form-control"
                          placeholder="Username"
                          v-model="user.username"
                          required
                          autofocus
                        />
                      </div>
                    </div>

                    <div class="d-flex flex-row align-items-center mb-4">
                      <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                      <div class="form-outline flex-fill mb-0">
                        <label for="password" class="sr-only">Password</label>
                        <input
                          type="password"
                          id="password"
                          class="form-control"
                          placeholder="Password"
                          v-model="user.password"
                          required
                        />
                      </div>
                    </div>

                    <div
                      class="d-flex justify-content-center mx-4 mb-3 mb-lg-4"
                    >
                      <router-link id="signIn" :to="{ name: 'register' }"
                        >Need an account?</router-link
                      >
                      <button type="submit">Sign in</button>
                    </div>
                  </form>
                </div>
                <div
                  class="
                    col-md-10 col-lg-6 col-xl-7
                    d-flex
                    align-items-center
                    order-1 order-lg-2
                  "
                >
                  <img
                    src="https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,h_1200,q_75,w_1200/v1/clients/columbus/scioto_mile_0052c2_51c16c33-b7d4-44c9-ac13-26f47e88f018.jpg"
                    class="img-fluid"
                    alt="Sample image"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>
#login {
  margin-right: 35%;
  margin-left: 35%;
}
#signIn {
  padding-right: 10px;
  color: #1a5270;
}
h2 {
  color: #1a5270;
}
#buttons {
  padding-top: 10px;
}
</style>
