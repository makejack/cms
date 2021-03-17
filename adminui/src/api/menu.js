import http from '../utils/http'

export function MenuList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function MenuDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function MenuCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function MenuEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function MenuChangeOrder(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu/order',
            method: 'put',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function MenuDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/navmenu/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}