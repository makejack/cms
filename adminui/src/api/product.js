import http from '../utils/http'

export function ProductList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/product/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ProductGet(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/product/'+id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ProductCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/product',
            method: 'Post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ProductEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/product',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ProductDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/product/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}