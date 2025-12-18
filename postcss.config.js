module.exports = {
  plugins: [
    // Tailwind CSS
    require('tailwindcss'),
    
    // Autoprefixer for vendor prefixes
    require('autoprefixer')({
      overrideBrowserslist: [
        '> 1%',
        'last 2 versions',
        'not dead',
        'not ie 11'
      ],
      grid: true,
      flexbox: 'no-2009'
    }),
    
    // PurgeCSS for production (removes unused CSS)
    ...(process.env.NODE_ENV === 'production' ? [
      require('@fullhuman/postcss-purgecss')({
        content: [
          './VoxTics/Views/**/*.cshtml',
          './VoxTics/Areas/**/*.cshtml',
          './VoxTics/wwwroot/js/**/*.js',
          './VoxTics/Controllers/**/*.cs',
          './VoxTics/Models/**/*.cs'
        ],
        defaultExtractor: content => content.match(/[\w-/:]+(?<!:)/g) || [],
        safelist: {
          standard: [
            // Always keep these classes
            'btn',
            'btn-primary',
            'btn-secondary',
            'btn-outline',
            'btn-ghost',
            'btn-sm',
            'btn-lg',
            'card',
            'card-glass',
            'input',
            'input-error',
            'form-group',
            'form-label',
            'form-error',
            'form-help',
            'nav',
            'nav-link',
            'badge',
            'badge-primary',
            'badge-secondary',
            'badge-success',
            'badge-warning',
            'badge-error',
            'alert',
            'alert-info',
            'alert-success',
            'alert-warning',
            'alert-error',
            'modal-overlay',
            'modal-content',
            'modal-header',
            'modal-body',
            'modal-footer',
            'table',
            'table-striped',
            'spinner',
            'spinner-sm',
            'spinner-md',
            'spinner-lg',
            'key',
            'key-dark',
            'key-space',
            'glass-light',
            'glass-dark',
            'text-gradient-primary',
            'text-gradient-secondary',
            'hover-lift',
            'hover-scale',
            'hover-glow',
            'focus-ring',
            'container-apple',
            'aspect-video',
            'aspect-square',
            'aspect-portrait',
            'safe-top',
            'safe-bottom',
            'safe-left',
            'safe-right',
            'no-print',
            'print-only'
          ],
          deep: [
            // Keep classes that might be dynamically generated
            /^animate-/,
            /^transition-/,
            /^duration-/,
            /^ease-/,
            /^apple-/,
            /^system-/,
            /^label-/,
            /^text-responsive-/,
            /^hover:/,
            /^focus:/,
            /^active:/,
            /^disabled:/,
            /^group-hover:/,
            /^sm:/,
            /^md:/,
            /^lg:/,
            /^xl:/,
            /^2xl:/,
            /^dark:/,
            /^motion-reduce:/,
            /^motion-safe:/,
            /^print:/
          ],
          greedy: [
            // Keep classes with dynamic parts
            /^bg-/,
            /^text-/,
            /^border-/,
            /^rounded-/,
            /^shadow-/,
            /^p-/,
            /^m-/,
            /^w-/,
            /^h-/,
            /^flex/,
            /^grid/,
            /^space-/,
            /^gap-/
          ]
        },
        // Custom extractor for C# Razor syntax
        extractors: [
          {
            extractor: content => {
              // Extract classes from C# string interpolations and Razor syntax
              const matches = content.match(/class\s*=\s*["']([^"']+)["']/g) || [];
              const classes = matches.map(match => {
                const classMatch = match.match(/class\s*=\s*["']([^"']+)["']/);
                return classMatch ? classMatch[1] : '';
              }).join(' ');
              
              // Also extract from @class attributes
              const atClassMatches = content.match(/@class\s*=\s*["']([^"']+)["']/g) || [];
              const atClasses = atClassMatches.map(match => {
                const classMatch = match.match(/@class\s*=\s*["']([^"']+)["']/);
                return classMatch ? classMatch[1] : '';
              }).join(' ');
              
              const allClasses = `${classes} ${atClasses}`;
              return allClasses.match(/[\w-/:]+(?<!:)/g) || [];
            },
            extensions: ['cshtml', 'cs']
          }
        ]
      })
    ] : []),
    
    // CSS Nano for production minification
    ...(process.env.NODE_ENV === 'production' ? [
      require('cssnano')({
        preset: [
          'default',
          {
            // Disable unsafe optimizations
            mergeIdents: false,
            reduceIdents: false,
            discardUnused: false,
            
            // Safe optimizations
            autoprefixer: false, // Already handled by autoprefixer above
            colormin: true,
            convertValues: true,
            discardComments: {
              removeAll: true
            },
            discardDuplicates: true,
            discardEmpty: true,
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
            reduceInitial: true,
            reduceTransforms: true,
            svgo: {
              plugins: [
                {
                  name: 'preset-default',
                  params: {
                    overrides: {
                      removeViewBox: false
                    }
                  }
                }
              ]
            },
            uniqueSelectors: true
          }
        ]
      })
    ] : []),
    
    // CSS Stats for analysis (development only)
    ...(process.env.NODE_ENV === 'development' && process.env.CSS_STATS ? [
      require('postcss-reporter')({
        clearReportedMessages: true,
        throwError: false
      })
    ] : [])
  ]
};