import http from '../utils/http'

export function CustomFormValueTable(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/customform/table',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function CustomFormValueDelete(id) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/customform/value/' + id,
            method: 'delete'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}