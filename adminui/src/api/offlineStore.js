import http from '../utils/http'

export function OfflinestoreList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/offlinestore/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function OfflinestoreDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/offlinestore/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function OfflinestoreCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/offlinestore',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function OfflinestoreEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/offlinestore',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function OfflinestoreDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/offlinestore/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}