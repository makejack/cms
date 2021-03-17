import axios from 'axios'
import store from '@/store'
import { Message } from 'element-ui'

axios.defaults.baseURL = process.env.NODE_ENV === 'production' ? 'http://www.veincity.com/api/' : 'api/'
axios.defaults.timeout = 5000

axios.interceptors.request.use(config => {
    var token = store.getters['user/token']
    if (token) {
        config.headers['Authorization'] = "Bearer " + token
    }
    return config
}, error => {
    return Promise.reject(error)
}
)

axios.interceptors.response.use(response => {
    if (response.data.code !== 0) {
        Message({
            message: response.data.msg,
            type: "warning",
        });
    }
    return response.data
}, error => {
    return Promise.reject(error)
})

export default axios;