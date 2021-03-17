import http from '../utils/http'

export function ContentList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function SingleContentDetail(menuId) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent/content/' + menuId,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ContentDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ContentCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ContentEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function ContentDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/pagecontent/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}