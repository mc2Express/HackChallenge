var webpack = require('webpack');
var path = require('path');
var HtmlWebpackPlugin = require('html-webpack-plugin');

// Webpack Config
var webpackConfig = {
  entry: {
    'polyfills': './src/polyfills.browser.ts',
    'vendor': './src/vendor.browser.ts',
    'main': './src/main.browser.ts'
  },

  output: {
    path: path.resolve(__dirname, 'dist'),

  },

  plugins: [
    new webpack.optimize.OccurrenceOrderPlugin(true),
    new webpack.optimize.CommonsChunkPlugin({
      name: ['main', 'vendor', 'polyfills'],
      minChunks: Infinity
    }),
    new HtmlWebpackPlugin({
      template: './src/index.html'
    }), // Generates default index.html 
    new webpack.ContextReplacementPlugin(
      /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
      __dirname)
        ],

  module: {
    rules: [{
        test: /\.ts$/,
        loaders: ['awesome-typescript-loader', 'angular2-template-loader']
      },
      {
        test: /\.less$/,
        loaders: ['to-string-loader', 'css-loader', 'less-loader']
      },
        {
        test: /\.(scss|sass)/,
        loaders: ['to-string-loader', 'css-loader', 'sass-loader']
      },
      {
        test: /\.css$/,
        loaders: ['style-loader', 'css-loader']
      },
      {
        test: /\.html$/,
        loader: "html-loader"
      },
      {
        test: /\.json$/,
        loader: 'json-loader'
      }, {
        test: /\.(eot|svg|ttf|woff|woff2|otf)?(\?v=[0-9]\.[0-9]\.[0-9])?$$/,
        loader: 'file-loader?hash=sha512&digest=hex&name=[hash].[ext]'
      }, {
        test: /\.(jpe?g|png|gif|svg)$/,
        loader: 'file-loader?hash=sha512&digest=hex&name=[hash].[ext]'
      }
    ]
  }
};


// Our Webpack Defaults
var defaultConfig = {
  devtool: 'cheap-module-source-map',
  cache: true,
  output: {
    filename: '[name].bundle.js',
    sourceMapFilename: '[name].map',
    chunkFilename: '[id].chunk.js'
  },

  resolve: {
    modules: ['node_modules'],
    descriptionFiles: ['package.json'],
    extensions: ['.ts', '.js']
  },

  devServer: {
    historyApiFallback: true,
    watchOptions: {
      aggregateTimeout: 300,
      poll: 1000
    },
    proxy: {
      //use this proxy during development to redirect API requests to a backend server!
      '/api/**': {
        target: 'http://localhost:5000/',
        secure: false
      }
    }

  }

};

var webpackMerge = require('webpack-merge');
module.exports = webpackMerge(defaultConfig, webpackConfig);
