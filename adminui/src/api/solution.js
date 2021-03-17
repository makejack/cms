import http from '../utils/http'

export function SolutionList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/solution/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function SolutionDetail(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/solution/' + id,
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function SolutionCreate(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/solution',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function SolutionEdit(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/solution',
            method: 'put',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function SolutionDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/solution/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}