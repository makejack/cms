import router from '../router'
import store from '../store'

const whiteList = ['/login', '/register']

router.beforeEach((to, from, next) => {

    var token = store.getters['user/token']
    if (token) {
        if (whiteList.indexOf(to.path) !== -1) {
            return next({ path: '/' })
        }
    } else {
        if (whiteList.indexOf(to.path) === -1) {
            return next({ name: 'Login' })
        }
    }

    next()
})
