// src/App.vue

<template>
  <div>

    <div><img src="./assets/HawthorneBridge-Pano.jpg"></div>

    <nav class="navbar navbar-default">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand" href="#">MyWebApp</a>

          <router-link to="/home"
            class="btn btn-primary btn-margin"
            v-if="authenticated" >
              Home
          </router-link>

          <router-link to="/project"
            class="btn btn-primary btn-margin"
            v-if="authenticated">
              Projects
          </router-link>

          <router-link to="/event"
            class="btn btn-primary btn-margin"
            v-if="authenticated">
              Events
          </router-link>

          <router-link to="/blog"
            class="btn btn-primary btn-margin"
            v-if="authenticated">
              My Blog
          </router-link>
          
          <button
            id="qsLoginBtn"
            class="btn btn-primary btn-margin"
            v-if="!authenticated"
            @click="login">
              Log In
          </button>

          <button
            id="qsLogoutBtn"
            class="btn btn-primary btn-margin"
            v-if="authenticated"
            @click="logout">
              Log Out
          </button>

        </div>
      </div>
    </nav>

    <div class="container">
      <router-view
        :auth="auth"
        :authenticated="authenticated">
      </router-view>
    </div>
  </div>
</template>

<script>
    import auth from './auth/AuthService'
    export default {
    name: 'app',
    data () {
        return {
            auth,
            authenticated: auth.authenticated
        }
    },
    created () {
        auth.authNotifier.on('authChange', authState => {
            this.authenticated = authState.authenticated
        })
        if (auth.getAuthenticatedFlag() === 'true') {
            auth.renewSession()
        }
    },
    methods: {
        login () {
            auth.login()
        },
        logout () {
            auth.logout()
        }
    }
    }
</script>

<style>
@import '../node_modules/bootstrap/dist/css/bootstrap.css';
.btn-margin {
  margin-top: 7px
}
</style>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
