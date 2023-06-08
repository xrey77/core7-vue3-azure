<template>

<div class="card card-width bs-info-border-subtle">
  <div class="card-header bg-info">
    USER'S PROFILE NO.&nbsp; {{ userid }}
  </div>
  <div class="card-body">

    <form id="profileForm" @submit.prevent="submitProfile" enctype="multipart/form-data" method="POST">
        <div class="row">
            <div class="col">
                <div class="mb-3">
                    <input type="text" required v-model="firstname" class="form-control"  autocomplete="off">
                </div>
                <div class="mb-3">
                    <input type="text" required v-model="lastname" class="form-control" autocomplete="off">
                </div>
                <div class="mb-3">
                    <input type="email" v-model="email" class="form-control" readonly>
                </div>
                <div class="mb-3">
                    <input type="text" required v-model="mobile" class="form-control" autocomplete="off">
                </div>

            </div>
            <div class="col">
                <img id="userpic" class="usr" v-bind:src="profilepic" alt=""/>
                <div class="mb-3">
                    <input type="file" @change="changePicture($event)" class="form-control form-control-sm mt-3" accept=".png, .jpg, .jpeg, .gif"  />
                </div>

            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" v-model="chgPwd" @change="checkboxPassword" />
                    <label class="form-check-label" for="chgPwd">
                        Change Password
                    </label>
                </div>
            </div>
            <div class="col">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" v-model="chkMfa" @change="checkboxMFA" />
                    <label class="form-check-label" for="chkMfa">
                        2-Factor Authenticator
                    </label>
                </div>
            </div>
        </div>

        <div class="row">

            <div class="col">
              <div id="cpwd">
                <div class="mb-3">
                    <input type="text"  v-model="password" class="form-control" autocomplete="off">
                </div>
                <div class="mb-3">
                    <input type="text"  v-model="confpassword" class="form-control" autocomplete="off">
                </div>
              </div>
                <div id="mfa1">
                        <div v-if="qrcodeurl != null">
                            <img class="qrcode1" v-bind:src="qrcodeurl" alt="qrcodeurl"/>
                        </div>
                        <div v-if="qrcodeurl === null">
                            <img class="qrcode2" src="http://localhost:5073/resources/images/qrcode.png" alt="QRCODE" />
                        </div>

                </div>

            </div>
            <div class="col">
                <div id="mfa2">
                        <p class='text-danger'><strong>Requirements</strong></p>
                        <p>You need to install <strong>Google or Microsoft Authenticator</strong> in your Mobile Phone, once installed, click Enable Button below, and <strong>SCAN QR CODE</strong>, next time you login, another dialog window will appear, then enter the <strong>OTP CODE</strong> from your Mobile Phone in order for you to login.</p>
                        <div class="row">
                            <div class="col btn-1">
                                <button @click="enableMFA" type="button" class="btn btn-primary">Enable</button>
                            </div>
                            <div class="col col-3 btn-2">
                                <button @click="disableMFA" type="button" class="btn btn-secondary">Disable</button>
                            </div>
                        </div>

                    </div>

            </div>
        </div>

        <button id="save" type="submit" class="btn btn-info">save</button>

    </form>
  </div>
  <div class="card-footer">
    <div class="w-100 text-left text-danger">{{ profileMsg }}</div>
  </div>
</div>
</template>

<style scoped>
    .usr {
        width: 150px!important;
        height: auto;
    }
    .card-width {
        padding: 20px!important;
    }
    .btn-1 {
        max-width: 100px!important;
    }
    .btn-2 {
        float: left!important;
    }
    #save {
        margin-top: 30px!important;
    }
    .qrcode1 {
        float: right;
        width: 200px;
        height: 200px;
    }
    .qrcode2 {
        float: right;
        width: 200px;
        height: 200px;
        opacity: 0.5;
    }

</style>

<script>
import { defineComponent } from 'vue'
import $ from 'jquery';
import axios from 'axios';

const api = axios.create({
    baseURL: "http://localhost:5073",
    headers: {'Accept': 'application/json',
              'Content-Type': 'application/json'}
})

export default defineComponent({
    name: 'Profile-Page',
    data() {
        return {
            userid: null,
            token: null,
            lastname: null,
            firstname: null,
            email: null,
            mobile: null,
            password: null,
            confpassword: null,
            qrcoderul: null,
            profileMsg: null,
            profilepic: "",
            chgPwd: false,
            chkMfa: false,
        }
    },
    mounted(){
        this.userid = sessionStorage.getItem('USERID');
        this.token = sessionStorage.getItem("TOKEN");
        $("#cpwd").hide();
        $("#mfa1").hide();
        $("#mfa2").hide();  

        api.get("/api/getuserbyid/" + this.userid, { headers: {
            Authorization: `Bearer ${this.token}`
        }} )
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.profileMsg = res.data.user.message;
                    this.firstname = res.data.user.firstname;
                    this.lastname = res.data.user.lastname;
                    this.email = res.data.user.email;
                    this.mobile = res.data.user.mobile;
                    this.profilepic = res.data.user.profilepic;
                    this.qrcodeurl = res.data.user.qrcodeurl;
                    return;
                } else {
                  this.profileMsg = res.data.message;
                    return;
                }
              }, (error) => {
                    this.profileMsg = error.message;
                    return;
            });


    },
    methods: {
        submitProfile: function() {
            if ($('#chkPwd').is(":checked")) {            
                if (this.password != this.confpassword) {
                    this.profileMsg = "New Password does not matched.";
                    setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                }
            }
            const data =JSON.stringify({ lastname: this.lastname, 
                firstname: this.firstname, mobile: this.mobile,
                password: this.password });

            api.post("/api/updateprofile/" + this.userid, data, { headers: {
            Authorization: `Bearer ${this.token}`
            }} )
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.profileMsg = res.data.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 300);
                    return;
                } else {
                  this.profileMsg = res.data.message;
                  window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 300);
                    return;
                }
              }, (error) => {
                    this.profileMsg = error.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 300);
                    return;
            });

        },
        changePicture: function(e) {
            $("#userpic").attr('src',URL.createObjectURL(e.target.files[0]));

            let formdata = new FormData();
            formdata.append('Id', this.userid);
            formdata.append('Profilepic',e.target.files[0]);

            api.post("/api/uploadpicture", formdata, { headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${this.token}`
            }} )
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.profileMsg = res.data.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                } else {
                  this.profileMsg = res.data.message;
                  window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                }
              }, (error) => {
                    this.profileMsg = error.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
            });

        },
        checkboxPassword: function() {
            if (this.chgPwd) {
                $("#cpwd").show();
                $("#mfa1").hide();  
                $("#mfa2").hide();  
                this.chkMfa = false;
                // $('#chkMfa').prop('checked', false);
            } else {
                this.password = null;
                this.confpassword = null;
                $("#cpwd").hide();
            }
        },
        checkboxMFA: function() {
            if (this.chkMfa) {
                $("#cpwd").hide();
                $("#mfa1").show();
                $("#mfa2").show();
                this.chgPwd = false;
                // $('#chkPwd').prop('checked', false);
            } else {
                $("#mfa1").hide();  
                $("#mfa2").hide();                  
            }
        },
        enableMFA: function() {
            const data =JSON.stringify({ Twofactorenabled: true });
            api.put("/api/enablemfa/" + this.userid, data, { headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
            }} )
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.profileMsg = res.data.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                } else {
                  this.profileMsg = res.data.message;
                  window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                }
              }, (error) => {
                    this.profileMsg = error.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
            });
        },
        disableMFA: function() {
            const data =JSON.stringify({ Twofactorenabled: false });
            api.put("/api/enablemfa/" + this.userid, data, { headers: {
                Authorization: `Bearer ${this.token}`
            }} )
            .then((res) => {
                if (res.data.statuscode == 200) {
                    this.profileMsg = res.data.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                } else {
                  this.profileMsg = res.data.message;
                  window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
                }
              }, (error) => {
                    this.profileMsg = error.message;
                    window.setTimeout(() => {
                        this.profileMsg = null;
                    }, 3000);
                    return;
            });

        },

    }

})

// $( document ).ready(function() {

//     $("#chkPwd").change(function() {
//         if ($('#chkPwd').is(":checked")) {
//             $("#cpwd").show();
//             $("#mfa1").hide();  
//             $("#mfa2").hide();  
//             $('#chkMfa').prop('checked', false);
//         } else {
//             $("#cpwd").hide();
//         }            
//     })

//     $("#chkMfa").change(function() {
//         if ($('#chkMfa').is(":checked")) {
//             $("#cpwd").hide();
//             $("#mfa1").show();
//             $("#mfa2").show();
//             $('#chkPwd').prop('checked', false);
//         } else {
//             $("#mfa1").hide();  
//             $("#mfa2").hide();  
//         }            
//     })
// });
</script>
