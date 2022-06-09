const path = require("path");

module.exports = {
    entry: {
        ReactComponent: "./wwwroot/ReactComponents/ReactComponents.js"
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/js/bundles"),
        filename: "[name].bundle.js"
    },

    mode: "development",

    module: {
        rules: [   //загрузчик для jsx
            {
                test: /\.jsx?$/, // определяем тип файлов
                exclude: /(node_modules)/,  // исключаем из обработки папку node_modules
                loader: "babel-loader",   // определяем загрузчик
                options: {
                    presets: ["@babel/preset-react"]    // используемые плагины
                }
            },
            {
                test: /\.css$/,
                use: [
                    // [style-loader](/loaders/style-loader)
                    { loader: 'style-loader' },

                    // [css-loader](/loaders/css-loader)
                    {
                        loader: 'css-loader',
                        options: {
                            modules: true
                        }
                    }
                ]
            }
        ]
    }
};