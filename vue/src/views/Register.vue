<template>
<<<<<<< HEAD
  <section class="vh-100">
    <div class="container h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-lg-12 col-xl-11">
          <div class="card text-black" style="border-radius: 25px">
            <div class="card-body p-md-5">
              <div class="row justify-content-center">
                <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">
                  <form class="form-register" @submit.prevent="register">
                    
                    <h2 class="h3 mb-3 font-weight-normal">Create Account</h2>

                    <div
                      class="alert alert-danger"
                      role="alert"
                      v-if="registrationErrors"
                    >
                      {{ registrationErrorMsg }}
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
=======
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h2 class="h3 mb-3 font-weight-normal">Create Account</h2>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
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
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <router-link id="account" v-bind:to="{ name: 'login' }">Have an account?</router-link>
      <input id="submit" type="submit" value ="Create Account" />
  
>>>>>>> 917c86d617bef8f1348f5ff10416b8a589d684f9

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

                    <div class="d-flex flex-row align-items-center mb-4">
                      <i class="fas fa-lock fa-lg me-3 fa-fw"></i>
                      <div class="form-outline flex-fill mb-0">
                        <label for="password" class="sr-only">Password</label>
                        <input
                          type="password"
                          id="confirmPassword"
                          class="form-control"
                          placeholder="Confirm Password"
                          v-model="user.confirmPassword"
                          required
                        />
                      </div>
                    </div>

                    <div
                      class="d-flex justify-content-center mx-4 mb-3 mb-lg-4"
                    >
                      <router-link id="account" v-bind:to="{ name: 'login' }"
                        >Have an account?</router-link
                      >
                      <input id="submit" type="submit" value="Create Account" />
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
                    src="https://livability.com/wp-content/uploads/2018/11/ColumbusOH-ShortNorth1.jpg"
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
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style scoped>
input,
#account {
  margin: 15px;
}
#register {
  margin-left: 35%;
  margin-right: 35%;
}
#submit {
  background-color: #208b77;
  border: black;
  border-radius: 5px;
  color: #ead6c7;
}
#submit:hover {
  text-decoration: underline;
}
</style>
