import http from '../utils/http'

export function WarrantyActivationList(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/warrantyactivation/list',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}