<template>
<div class="modal fade" id="staticMfa" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticMfaLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header bg-warning">
        <h1 class="modal-title fs-5 text-white" id="staticMfaLabel">2-Factor Authenticator</h1>
        <button @click="closeMfa" type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <form id="mfaForm" @submit.prevent="submitOTP">
          <div class="mb-3">
            <input type="text" maxlength="6" required class="form-control" v-model="otpcode" placeholder="enter 6 digits OTP Code" autocomplete="off">
        </div>
        <button type="submit" class="btn btn-warning">submit</button>
        <button id="mfaReset" type="reset" class="btn btn-warning">reset</button>

        </form>
      </div>
      <div class="modal-footer">
        <div id="mfaMsg" class="w-100 text-left text-danger">{{ otpMessage }}</div>
      </div>
    </div>
  </div>
</div>    
</template>

<style scoped>
  #mfaReset {
    visibility: hidden;
  }
</style>

<script>
 import { defineComponent } from 'vue';
 import $ from 'jquery';
 import axios from 'axios';

 const api = axios.create({
    baseURL: "http://localhost:5073",
    headers: {'Accept': 'application/json',
              'Content-Type': 'application/json'}
 })

 export default defineComponent({
    name: 'Mfa-OTP',
    data() {
        return {
            userId: "",
            otpcode: "",
            otpMessage: ""
        }
    },
    mounted() {
      this.userId = sessionStorage.getItem("USERID");
    },
    methods: {
        submitOTP: function() {
            const data =JSON.stringify({ id: this.userId, otp: this.otpcode });
            api.post("/validateotp", data)
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.otpMessage = res.data.message;
                    sessionStorage.setItem("USERNAME", res.data.username);
                    $("#mfaReset").click();
                    window.setTimeout(() => {
                      window.location.reload();
                    }, 3000);
                    return;
                } else {
                  this.otpMessage = res.data.message;
                    return;
                }
              }, (error) => {
                    this.otpMessage = error.message;
                    return;
            });

        },
        closeMfa: function() {
            $("#mfaReset").click();
            this.otpMessage = '';
            sessionStorage.removeItem('USERID');
            sessionStorage.removeItem('USERNAME');
            sessionStorage.removeItem('TOKEN');
            sessionStorage.removeItem('USERPIC');            
            sessionStorage.clear();
            window.location.href="/";
        },
    }
 })
</script>