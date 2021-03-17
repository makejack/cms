export const isTel = (rule, value, callback) => {
    if (value) {
        let tel = /^1\d{10}$/;
        if (!tel.test(value)) {
            return callback(new Error("手机号码格式不正确"));
        }
    }
    callback();
};
export const isEmail = (rule, value, callback) => {
    if (value) {
        var email = /^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
        if (!email.test(value)) {
            return callback(new Error("邮箱格式不正确"));
        }
    }
    callback();
}; 