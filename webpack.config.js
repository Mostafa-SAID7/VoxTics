const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CssMinimizerPlugin = require('css-minimizer-webpack-plugin');
const TerserPlugin = require('terser-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;
const CompressionPlugin = require('compression-webpack-plugin');

const isProduction = process.env.NODE_ENV === 'production';

module.exports = {
  mode: isProduction ? 'production' : 'development',
  
  entry: {
    // Main application bundle
    app: './VoxTics/wwwroot/js/app.js',
    
    // Vendor libraries
    vendor: [
      './VoxTics/wwwroot/lib/bootstrap/dist/js/bootstrap.bundle.min.js',
      './VoxTics/wwwroot/lib/jquery/dist/jquery.min.js'
    ],
    
    // Design system styles
    styles: './VoxTics/wwwroot/css/input.css',
    
    // Admin-specific bundle
    admin: './VoxTics/wwwroot/js/admin.js'
  },
  
  output: {
    path: path.resolve(__dirname, 'VoxTics/wwwroot/dist'),
    filename: isProduction ? '[name].[contenthash].js' : '[name].js',
    chunkFilename: isProduction ? '[name].[contenthash].chunk.js' : '[name].chunk.js',
    publicPath: '/dist/',
    clean: true
  },
  
  module: {
    rules: [
      // JavaScript/TypeScript
      {
        test: /\.m?js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: [
              ['@babel/preset-env', {
                targets: {
                  browsers: ['> 1%', 'last 2 versions', 'not dead']
                },
                useBuiltIns: 'usage',
                corejs: 3
              }]
            ],
            plugins: [
              '@babel/plugin-syntax-dynamic-import',
              '@babel/plugin-proposal-class-properties'
            ]
          }
        }
      },
      
      // CSS/SCSS
      {
        test: /\.css$/,
        use: [
          isProduction ? MiniCssExtractPlugin.loader : 'style-loader',
          {
            loader: 'css-loader',
            options: {
              importLoaders: 1,
              sourceMap: !isProduction
            }
          },
          {
            loader: 'postcss-loader',
            options: {
              postcssOptions: {
                plugins: [
                  require('tailwindcss'),
                  require('autoprefixer'),
                  ...(isProduction ? [require('cssnano')] : [])
                ]
              }
            }
          }
        ]
      },
      
      // SCSS
      {
        test: /\.scss$/,
        use: [
          isProduction ? MiniCssExtractPlugin.loader : 'style-loader',
          'css-loader',
          'sass-loader'
        ]
      },
      
      // Images
      {
        test: /\.(png|jpe?g|gif|svg|webp)$/i,
        type: 'asset',
        parser: {
          dataUrlCondition: {
            maxSize: 8 * 1024 // 8kb
          }
        },
        generator: {
          filename: 'images/[name].[hash][ext]'
        }
      },
      
      // Fonts
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/i,
        type: 'asset/resource',
        generator: {
          filename: 'fonts/[name].[hash][ext]'
        }
      }
    ]
  },
  
  plugins: [
    // Clean dist folder
    new CleanWebpackPlugin(),
    
    // Extract CSS
    new MiniCssExtractPlugin({
      filename: isProduction ? '[name].[contenthash].css' : '[name].css',
      chunkFilename: isProduction ? '[name].[contenthash].chunk.css' : '[name].chunk.css'
    }),
    
    // Compression for production
    ...(isProduction ? [
      new CompressionPlugin({
        algorithm: 'gzip',
        test: /\.(js|css|html|svg)$/,
        threshold: 8192,
        minRatio: 0.8
      })
    ] : []),
    
    // Bundle analyzer (only when ANALYZE=true)
    ...(process.env.ANALYZE ? [
      new BundleAnalyzerPlugin({
        analyzerMode: 'static',
        openAnalyzer: false,
        reportFilename: 'bundle-report.html'
      })
    ] : [])
  ],
  
  optimization: {
    minimize: isProduction,
    minimizer: [
      new TerserPlugin({
        terserOptions: {
          compress: {
            drop_console: isProduction,
            drop_debugger: isProduction
          },
          format: {
            comments: false
          }
        },
        extractComments: false
      }),
      new CssMinimizerPlugin({
        minimizerOptions: {
          preset: [
            'default',
            {
              discardComments: { removeAll: true },
              normalizeWhitespace: true,
              colormin: true,
              convertValues: true,
              discardDuplicates: true,
              discardEmpty: true,
              mergeIdents: true,
              mergeLonghand: true,
              mergeRules: true,
              minifyFontValues: true,
              minifyGradients: true,
              minifyParams: true,
              minifySelectors: true,
              normalizeCharset: true,
              normalizeDisplayValues: true,
              normalizePositions: true,
              normalizeRepeatStyle: true,
              normalizeString: true,
              normalizeTimingFunctions: true,
              normalizeUnicode: true,
              normalizeUrl: true,
              orderedValues: true,
              reduceIdents: true,
              reduceInitial: true,
              reduceTransforms: true,
              svgo: true,
              uniqueSelectors: true
            }
          ]
        }
      })
    ],
    
    // Code splitting
    splitChunks: {
      chunks: 'all',
      cacheGroups: {
        // Vendor libraries
        vendor: {
          test: /[\\/]node_modules[\\/]/,
          name: 'vendors',
          chunks: 'all',
          priority: 20
        },
        
        // Common chunks
        common: {
          name: 'common',
          minChunks: 2,
          chunks: 'all',
          priority: 10,
          reuseExistingChunk: true
        },
        
        // CSS chunks
        styles: {
          name: 'styles',
          test: /\.css$/,
          chunks: 'all',
          enforce: true
        }
      }
    },
    
    // Runtime chunk
    runtimeChunk: {
      name: 'runtime'
    }
  },
  
  resolve: {
    extensions: ['.js', '.jsx', '.ts', '.tsx', '.css', '.scss'],
    alias: {
      '@': path.resolve(__dirname, 'VoxTics/wwwroot'),
      '@css': path.resolve(__dirname, 'VoxTics/wwwroot/css'),
      '@js': path.resolve(__dirname, 'VoxTics/wwwroot/js'),
      '@images': path.resolve(__dirname, 'VoxTics/wwwroot/images'),
      '@components': path.resolve(__dirname, 'VoxTics/Views/Shared/Components')
    }
  },
  
  devtool: isProduction ? 'source-map' : 'eval-source-map',
  
  devServer: {
    static: {
      directory: path.join(__dirname, 'VoxTics/wwwroot')
    },
    compress: true,
    port: 3000,
    hot: true,
    open: false,
    proxy: {
      '/': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        secure: false
      }
    }
  },
  
  performance: {
    hints: isProduction ? 'warning' : false,
    maxEntrypointSize: 512000,
    maxAssetSize: 512000
  },
  
  stats: {
    colors: true,
    modules: false,
    children: false,
    chunks: false,
    chunkModules: false
  }
};

// Development-specific configuration
if (!isProduction) {
  module.exports.plugins.push(
    new (require('webpack')).HotModuleReplacementPlugin()
  );
}

// Production-specific optimizations
if (isProduction) {
  // Additional production plugins can be added here
  module.exports.plugins.push(
    // Generate manifest for ASP.NET Core
    new (require('webpack-manifest-plugin').WebpackManifestPlugin)({
      fileName: 'manifest.json',
      publicPath: '/dist/',
      writeToFileEmit: true
    })
  );
}