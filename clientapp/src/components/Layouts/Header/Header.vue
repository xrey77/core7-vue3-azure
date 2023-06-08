<template>
  <div class="container-fluid">
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/"><img class="logo" src="http://localhost:5073/resources/images/logo.png" alt="QATAR FOUNDATION" /></router-link>                
    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"> -->
   
          <button class="navbar-toggler" type="button"  data-bs-toggle="offcanvas" data-bs-target="#offcanvasMenu" aria-controls="offcanvasWithBothOptions">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <router-link class="nav-link active" to="/aboutus">About Us</router-link>                
              </li>
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle active" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  Services
                </a>
                <ul class="dropdown-menu">
                  <li>
                    <router-link class="dropdown-item" to="/productlist">Product List</router-link>                
                </li>
                  <li>
                    <router-link class="dropdown-item" to="/productcatalogs">Catalogs</router-link>                
                </li>
                  <li><hr class="dropdown-divider"></li>
                  <li>
                    <router-link class="dropdown-item" to="/productsearch">Search Product</router-link>                
                </li>
                </ul>
              </li>
              <li class="nav-item">
                <router-link class="nav-link active" to="/locateus">Locate Us</router-link>                
              </li>
            </ul>
            <div v-if="USERNAME === null || USERNAME === ''">
              <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                  <a class="nav-link active" href="/#" data-bs-toggle="modal" data-bs-target="#staticLogin">Login</a>                
                </li>
                <li class="nav-item">
                  <a class="nav-link active" href="/#" data-bs-toggle="modal" data-bs-target="#staticRegister">Register</a>                
                </li>            
              </ul>
            </div>
            <ul v-if="USERNAME != null" class="navbar-nav mr-auto">
                  <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle active" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                      <img class="user"  v-bind:src="USERPIC" />{{ USERNAME }}
                    </a>
                    <ul class="dropdown-menu">
                      <li>
                        <a @click="logout" class="dropdown-item" href="/#">LogOut</a>
                    </li>
                      <li>
                        <router-link class="dropdown-item" to="/profile">Profile</router-link>                
                    </li>
                      <li><hr class="dropdown-divider"></li>
                      <li>
                        <router-link class="dropdown-item" to="/#">Messenger</router-link>                
                    </li>
                    </ul>
                  </li>              
                </ul>


          </div>

        </div>
    </nav>
    <!-- OFFCANVAS MENU -->
    <div class="offcanvas offcanvas-end" data-bs-scroll="true" tabindex="-1" id="offcanvasMenu" aria-labelledby="offcanvasWithBothOptionsLabel">
      <div class="offcanvas-header bg-primary">
        <h5 class="offcanvas-title text-white" id="offcanvasWithBothOptionsLabel">Drawer Menu</h5>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
      </div>
      <div class="offcanvas-body">

        <ul class="nav flex-column">
          <li class="nav-item" data-bs-dismiss="offcanvas">
            <router-link class="nav-link active" to="/aboutus">About Us</router-link>                
          </li>
          <li class="nav-item"><hr/></li>
          <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle active" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  Services
                </a>
                <ul class="dropdown-menu">
                  <li data-bs-dismiss="offcanvas">
                    <router-link class="dropdown-item" to="/productlist">Product List</router-link>                
                </li>
                  <li data-bs-dismiss="offcanvas">
                    <router-link class="dropdown-item" to="/productcatalogs">Catalogs</router-link>                
                </li>
                  <li><hr class="dropdown-divider"></li>
                  <li data-bs-dismiss="offcanvas">
                    <router-link class="dropdown-item" to="/productsearch">Search Product</router-link>                
                </li>
                </ul>
              </li>
              <li class="nav-item"><hr/></li>

              <li class="nav-item" data-bs-dismiss="offcanvas">
                <router-link class="nav-link active" to="/locateus">Locate Us</router-link>                
              </li>
              <li class="nav-item"><hr/></li>

            </ul>
            <div v-if="USERNAME === null || USERNAME === ''">
              <ul class="nav flex-column">
                <li class="nav-item" data-bs-dismiss="offcanvas">
                  <a class="nav-link active" href="/#" data-bs-toggle="modal" data-bs-target="#staticLogin">Login</a>
                </li>
                <li class="nav-item"><hr/></li>

                <li class="nav-item" data-bs-dismiss="offcanvas">
                  <a class="nav-link active" href="/#" data-bs-toggle="modal" data-bs-target="#staticRegister">Register</a>
                </li>            
              </ul>
            </div>
            <ul v-if="USERNAME != null" class="navbar-nav mr-auto">
                  <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle active" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                      <img class="user"  v-bind:src="USERPIC" />{{ USERNAME }}
                    </a>
                    <ul class="dropdown-menu">
                      <li data-bs-dismiss="offcanvas">
                        <a @click="logout" class="dropdown-item" href="/#">LogOut</a>
                      </li>
                      <li class="nav-item"><hr/></li>
                      <li data-bs-dismiss="offcanvas">
                        <router-link class="dropdown-item" to="/profile">Profile</router-link>                
                      </li>
                      <li><hr class="dropdown-divider"></li>
                      <li data-bs-dismiss="offcanvas">
                        <router-link class="dropdown-item" to="/#">Messenger</router-link>                
                      </li>
                    </ul>
                  </li>              
        </ul>        

      </div>
    </div>
    

    <router-view />
    <Register/>
    <Login/>
  </div>
</template>

<style scoped>
  .logo {
    width: 50px;
    height: auto;
  }
  .user {
    width: 50px;
    height: auto;
    border-radius: 50%;
  }

#offcanvasMenu {
  max-width: 70%!important;
}
</style>

<script>
    import { defineComponent } from 'vue';
    import Register from '../../Auth/Register.vue';
    import Login from '../../Auth/Login.vue';

    export default defineComponent({
        name: 'Header-Page',
        components: {
            Register,
            Login
        },
        data() {
          return {
            USERNAME: String,
            USERPIC: String
          }
        },
        mounted() {
            this.USERNAME = sessionStorage.getItem('USERNAME');
            this.USERPIC = sessionStorage.getItem('USERPIC');
        },
        methods: {
          logout: function() {
            sessionStorage.removeItem('USERID');
            sessionStorage.removeItem('USERNAME');
            sessionStorage.removeItem('TOKEN');
            sessionStorage.removeItem('USERPIC');
            window.location.href="/";
          },
        }
    })
</script>
