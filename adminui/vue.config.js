const target = 'https://localhost:5001/'

module.exports = {
    publicPath: process.env.NODE_ENV === 'production' ? "/admin/" : "/",
    productionSourceMap: false,
    devServer: {
        proxy: {
            'uploads/': {
                target: target,
                changeOrigin: true,
            },
            'api/': {
                target: target,
                changeOrigin: true,
            }
        }
    },
    chainWebpack: config => {
        //移除Proload和Prefetch来实现懒加载
        config.plugins.delete('preload')
        config.plugins.delete('prefetch')
    }
}