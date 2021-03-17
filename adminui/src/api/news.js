import http from '../utils/http'

export function NewsList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/news/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function NewsDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/news/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function NewsCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/news',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function NewsEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/news',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function NewsDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/news/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}