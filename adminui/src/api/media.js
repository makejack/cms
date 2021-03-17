import http from '../utils/http'

export function UploadImg(data, uploadProgress) {
    return http({
        url: 'admin/media/upload/image',
        headers: { 'Content-Type': 'multipart/form-data' },
        timeout: 30000,
        method: 'post',
        data,
        onUploadProgress: uploadProgress
    })
}

export function TemplateFiles() {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/templatefiles',
            method: 'get'
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function GetFiles(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/getfiles',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function GetFileContent(params) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/file/content',
            method: 'get',
            params
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}


export function ChangeFileContent(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/file/content',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}


export function CreateFolder(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/folder/create',
            method: 'post',
            data
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}


export function Upload(data, uploadProgress) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/upload',
            headers: { 'Content-Type': 'multipart/form-data' },
            timeout: 30000,
            method: 'post',
            data,
            onUploadProgress: uploadProgress
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}

export function UploadFile(data) {
    return new Promise((resolve, reject) => {
        http({
            url: 'admin/media/upload/file',
            headers: { 'Content-Type': 'multipart/form-data' },
            timeout: 30000,
            method: 'post',
            data,
        }).then(res => {
            resolve(res)
        }).catch(err => {
            reject(err)
        })
    })
}
