import http from '../utils/http'

export function Login(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/auth/login',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function Register(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/auth/register',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}