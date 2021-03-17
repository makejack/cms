const tokenKey = "Token"
const userInfoKey = "User"

const state = {
    token: JSON.parse(sessionStorage.getItem(tokenKey)),
    userInfo: JSON.parse(sessionStorage.getItem(userInfoKey))
}

const mutations = {
    SET_TOKEN: (state, token) => {
        sessionStorage.setItem(tokenKey, JSON.stringify(token))
        state.token = token
    },
    REMOVE_TOKEN: (state) => {
        sessionStorage.removeItem(tokenKey)
        sessionStorage.removeItem(userInfoKey)
        state.token = ''
        state.userInfo = ''
    },
    SET_USERINFO: (state, user) => {
        sessionStorage.setItem(userInfoKey, JSON.stringify(user))
        state.userInfo = user
    }
}

const actions = {
    set_token({ commit }, token) {
        commit('SET_TOKEN', token)
    },
    remove_token({ commit }) {
        commit('REMOVE_TOKEN')
    },
    set_userinfo({ commit }, user) {
        commit('SET_USERINFO', user)
    }
}

const getters = {
    token: state => state.token,
    userInfo: state => state.userInfo
}

export default {
    namespaced: true,
    state,
    mutations,
    actions,
    getters
}