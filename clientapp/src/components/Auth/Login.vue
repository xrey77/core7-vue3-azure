<template>
<div>
<Mfa/>
<div class="modal fade" id="staticLogin" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticLoginLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header bg-primary">
        <h1 class="modal-title fs-5 text-white" id="staticLoginLabel">User's Login</h1>
        <button id="closeLogin" @click="closeLogin" type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <form id="loginForm" @submit.prevent="submitLogin" autocomplete="off">
          <div class="mb-3">
            <input type="text" required class="form-control" v-model="username" placeholder="enter Username" autocomplete="off">
        </div>
        <div class="mb-3">
            <input type="password" required class="form-control" v-model="password" placeholder="enter Password" autocomplete="off">
        </div>
        <button type="submit" class="btn btn-primary">login</button>
        <button id="loginReset" type="reset" class="btn btn-primary">reset</button>
        <button id="mfaModal" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticMfa">mfa</button>

        </form>
      </div>
      <div class="modal-footer">
        <div id="loginMsg" class="w-100 text-left text-danger">{{ loginMessage }}</div>
      </div>
    </div>
  </div>

</div>
</div>
</template>

<style scoped>
  #loginReset {
    visibility: hidden;
  }
  #mfaModal {
    visibility: hidden;
  }
</style>

<script lang="ts">
    import { defineComponent } from 'vue';
    import Mfa from './Mfa.vue';
    import $ from 'jquery';
    import axios from 'axios';

    const api = axios.create({
        baseURL: "http://localhost:5073",
        headers: {'Accept': 'application/json',
                  'Content-Type': 'application/json'}
    })

  export default defineComponent({
    name: 'Login-User',
    components: {
      Mfa
    },
    data() {
      return {
        username: '',
        password: '',
        loginMessage: ''
      }
    },
    methods: {
        closeLogin: function() {
            this.loginMessage = '';
            $("#loginReset").click();
        },
        submitLogin: function() {    
          this.loginMessage='Please wait...';
            const data =JSON.stringify({ username: this.username, password: this.password });
            api.post("/signin", data)
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.loginMessage = res.data.message;

                    if (res.data.qrcodeurl != null) {
                        sessionStorage.setItem('USERID',res.data.id);
                        sessionStorage.setItem('TOKEN',res.data.token);
                        sessionStorage.setItem('ROLE',res.data.roles);
                        sessionStorage.setItem('USERPIC',res.data.profilepic);
                        $("#loginReset").click();
                        $("#mfaModal").click();

                    } else {
                        sessionStorage.setItem('USERID',res.data.id);
                        sessionStorage.setItem('USERNAME',res.data.username);
                        sessionStorage.setItem('TOKEN',res.data.token);                        
                        sessionStorage.setItem('ROLE',res.data.roles);
                        sessionStorage.setItem('USERPIC',res.data.profilepic);
                        $("#loginReset").click();
                        window.location.reload();
                    }
                    return;
                } else {
                  this.loginMessage = res.data.message;
                    return;
                }
              }, (error) => {
                    this.loginMessage = error.message;
                    return;
            });

        },        
      }
    })
</script>