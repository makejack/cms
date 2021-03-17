import Vue from 'vue'
import VueRouter from 'vue-router'

import Layot from '../layout'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: Layot,
    redirect: '/menu',
    children: [{
      path: '/product',
      name: 'Product',
      component: () => import(/* webpackChunkName: "product" */ '../views/Product/index.vue')
    }, {
      path: '/product/info',
      name: 'ProductInfo',
      component: () => import(/* webpackChunkName: "productinfo" */ '../views/Product/Info.vue')
    }, {
      path: '/news',
      name: 'News',
      component: () => import(/* webpackChunkName: "news" */ '../views/News/index.vue')
    }, {
      path: '/news/info',
      name: 'NewsInfo',
      component: () => import(/* webpackChunkName: "newsinfo" */ '../views/News/Info.vue')
    }, {
      path: '/solution',
      name: 'Solution',
      component: () => import(/* webpackChunkName: "solution" */ '../views/Solution/index.vue')
    }, {
      path: '/solution/info',
      name: 'SolutionInfo',
      component: () => import(/* webpackChunkName: "solutioninfo" */ '../views/Solution/Info.vue')
    }, {
      path: '/category',
      name: 'Category',
      component: () => import(/* webpackChunkName: "category" */ '../views/Category/index.vue')
    }, {
      path: '/category/info',
      name: 'CategoryInfo',
      component: () => import(/* webpackChunkName: "categoryinfo" */ '../views/Category/Info.vue')
    }, {
      path: '/onlinemessage',
      name: 'OnlineMessage',
      component: () => import(/* webpackChunkName: "onlinemessage" */ '../views/OnlineMessage/index.vue')
    }, {
      path: '/offlinestore',
      name: 'OfflineStore',
      component: () => import(/* webpackChunkName: "offlinestore" */ '../views/OfflineStore/index.vue')
    }, {
      path: '/offlinestore/info',
      name: 'OfflineStoreInfo',
      component: () => import(/* webpackChunkName: "offlinestoreinfo" */ '../views/OfflineStore/Info.vue')
    }, {
      path: '/warrantyactivation',
      name: 'WarrantyActivation',
      component: () => import(/* webpackChunkName: "warrantyactivation" */ '../views/WarrantyActivation/index.vue')
    }, {
      path: '/user/changepwd',
      name: 'ChangePwd',
      component: () => import(/* webpackChunkName: "changepwd" */ '../views/User/ChangePwd.vue')
    }, {
      path: '/websitesetting',
      name: 'WebsiteSetting',
      component: () => import(/* webpackChunkName: "WebisteSetting" */ '../views/WebisteSetting/index.vue')
    }, {
      path: '/menu',
      name: 'Menu',
      component: () => import(/* webpackChunkName: "menu" */ '../views/Menu/index.vue')
    }, {
      path: '/menu/info',
      name: 'MenuInfo',
      component: () => import(/* webpackChunkName: "menuinfo" */ '../views/Menu/Info.vue')
    }, {
      path: '/content',
      name: 'PageContent',
      component: () => import(/* webpackChunkName: "pagecontent" */ '../views/PageContent/index.vue'),
      children: [{
        path: '',
        components: {
          default: () => import('../views/PageContent/components/Table.vue'),
          single: () => import("../views/PageContent/components/Single.vue"),
          form: () => import('../views/PageContent/components/Form.vue')
        }
      }]
    }, {
      path: '/content/info',
      name: 'PageContentInfo',
      component: () => import(/* webpackChunkName: "contentinfo" */ '../views/PageContent/Info.vue')
    }, {
      path: '/template',
      name: 'Template',
      component: () => import(/* webpackChunkName: "template" */ '../views/Template/index.vue')
    }, {
      path: '/template/info',
      name: 'TemplateInfo',
      component: () => import(/* webpackChunkName: "templateinfo" */ '../views/Template/Info.vue')
    }, {
      path: '/upload',
      name: 'Upload',
      component: () => import(/* webpackChunkName: "upload" */ '../views/Template/UploadMultipleFile.vue')
    }, {
      path: '/user',
      name: 'UserList',
      component: () => import(/* webpackChunkName: "user" */ '../views/User/List.vue')
    }, {
      path: '/user/info',
      name: 'UserInfo',
      component: () => import(/* webpackChunkName: "userinfo" */ '../views/User/Info.vue')
    }]
  },
  {
    path: '/login',
    name: 'Login',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "login" */ '../views/Auth/Login.vue')
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import(/* webpackChunkName: "register" */ '../views/Auth/Register.vue')
  }
]

const router = new VueRouter({
  base: '/admin/',
  routes
})

export default router
