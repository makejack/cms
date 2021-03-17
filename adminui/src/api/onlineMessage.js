import http from '../utils/http'

export function OnlineMessageList(params) {
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