import http from '../utils/http'

export function ChnagePwd(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user/changepwd',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function UserList() {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user/list',
            method: 'get',
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function UserDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CreateUser(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function EditUser(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}


export function DeleteUser(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/user/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}
