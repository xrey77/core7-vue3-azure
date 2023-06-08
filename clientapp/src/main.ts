import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
// import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'bootstrap/dist/js/bootstrap.bundle'
import 'jquery';

// import axios from 'axios';
// import VueAxios from 'vue-axios'


createApp(App).use(router).mount('#app')
// App.use(axios);
