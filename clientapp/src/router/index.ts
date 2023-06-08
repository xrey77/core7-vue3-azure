import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AboutView from '../views/AboutView.vue'
import LocateView from '../views/LocateView.vue'
import Productlist from '@/components/Products/List.vue'
import ProductCatalogs from '@/components/Products/Catalogs.vue'
import ProductSearch from '@/components/Products/Search.vue'
import Profile from '@/components/users/profile.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/aboutus',
    name: 'aboutus',
    component: AboutView
  },
  {
    path: '/locateus',
    name: 'locateus',
    component: LocateView
  },
  {
    path: '/productlist',
    name: 'productlist',
    component: Productlist
  },
  {
    path: '/productcatalogs',
    name: 'productcatalogs',
    component: ProductCatalogs
  },
  {
    path: '/productsearch',
    name: 'productsearch',
    component: ProductSearch
  },
  {
    path: '/profile',
    name: 'profile',
    component: Profile
  },

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
