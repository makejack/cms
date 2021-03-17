import http from '../utils/http'

export function LoadWebsiteSetting() {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/websitesetting',
            method: 'get',
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function WebsiteSettingSave(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/websitesetting',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}