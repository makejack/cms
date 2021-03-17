import http from '../utils/http'

export function CategoryAll(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category/all',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CategoryList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CategoryDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CategoryCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CategoryEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CategoryDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/category/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}