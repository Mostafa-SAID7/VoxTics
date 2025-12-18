/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './VoxTics/Views/**/*.{cshtml,html}',
    './VoxTics/Areas/**/*.{cshtml,html}',
    './VoxTics/wwwroot/js/**/*.js',
    './VoxTics/Controllers/**/*.cs',
    './VoxTics/Models/**/*.cs'
  ],
  darkMode: 'media', // Supports both dark and light modes
  theme: {
    extend: {
      // Apple Keyboard+ Design System Colors
      colors: {
        apple: {
          // Primary Apple Colors
          blue: '#007AFF',
          'blue-light': '#40A9FF',
          'blue-dark': '#0051D5',
          
          // Grayscale
          white: '#FFFFFF',
          'gray-50': '#F9FAFB',
          'gray-100': '#F3F4F6',
          'gray-200': '#E5E7EB',
          'gray-300': '#D1D5DB',
          'gray-400': '#9CA3AF',
          'gray-500': '#6B7280',
          'gray-600': '#4B5563',
          'gray-700': '#374151',
          'gray-800': '#1F2937',
          'gray-900': '#111827',
          
          // System Colors
          red: '#FF3B30',
          orange: '#FF9500',
          yellow: '#FFCC00',
          green: '#34C759',
          mint: '#00C7BE',
          teal: '#30B0C7',
          cyan: '#32D74B',
          indigo: '#5856D6',
          purple: '#AF52DE',
          pink: '#FF2D92',
          brown: '#A2845E',
          
          // Keyboard Inspired
          'key-white': '#F5F5F7',
          'key-black': '#1D1D1F',
          'key-silver': '#E8E8ED',
          'key-space': '#86868B'
        },
        
        // System Background Colors
        system: {
          'background': 'var(--system-background)',
          'background-secondary': 'var(--system-background-secondary)',
          'background-tertiary': 'var(--system-background-tertiary)',
          'fill': 'var(--system-fill)',
          'fill-secondary': 'var(--system-fill-secondary)',
          'fill-tertiary': 'var(--system-fill-tertiary)',
          'fill-quaternary': 'var(--system-fill-quaternary)'
        },
        
        // Label Colors
        label: {
          'primary': 'var(--label-primary)',
          'secondary': 'var(--label-secondary)',
          'tertiary': 'var(--label-tertiary)',
          'quaternary': 'var(--label-quaternary)'
        }
      },
      
      // Typography
      fontFamily: {
        'sf-pro': ['-apple-system', 'BlinkMacSystemFont', 'SF Pro Display', 'Segoe UI', 'Roboto', 'sans-serif'],
        'sf-mono': ['SF Mono', 'Monaco', 'Inconsolata', 'Roboto Mono', 'monospace'],
        'keyboard': ['SF Pro Display', 'Helvetica Neue', 'Arial', 'sans-serif']
      },
      
      fontSize: {
        'xs': ['0.75rem', { lineHeight: '1rem' }],
        'sm': ['0.875rem', { lineHeight: '1.25rem' }],
        'base': ['1rem', { lineHeight: '1.5rem' }],
        'lg': ['1.125rem', { lineHeight: '1.75rem' }],
        'xl': ['1.25rem', { lineHeight: '1.75rem' }],
        '2xl': ['1.5rem', { lineHeight: '2rem' }],
        '3xl': ['1.875rem', { lineHeight: '2.25rem' }],
        '4xl': ['2.25rem', { lineHeight: '2.5rem' }],
        '5xl': ['3rem', { lineHeight: '1' }],
        '6xl': ['3.75rem', { lineHeight: '1' }],
        '7xl': ['4.5rem', { lineHeight: '1' }],
        '8xl': ['6rem', { lineHeight: '1' }],
        '9xl': ['8rem', { lineHeight: '1' }]
      },
      
      // Spacing (Apple's 8pt grid system)
      spacing: {
        '0.5': '0.125rem', // 2px
        '1': '0.25rem',    // 4px
        '1.5': '0.375rem', // 6px
        '2': '0.5rem',     // 8px
        '2.5': '0.625rem', // 10px
        '3': '0.75rem',    // 12px
        '3.5': '0.875rem', // 14px
        '4': '1rem',       // 16px
        '5': '1.25rem',    // 20px
        '6': '1.5rem',     // 24px
        '7': '1.75rem',    // 28px
        '8': '2rem',       // 32px
        '9': '2.25rem',    // 36px
        '10': '2.5rem',    // 40px
        '11': '2.75rem',   // 44px
        '12': '3rem',      // 48px
        '14': '3.5rem',    // 56px
        '16': '4rem',      // 64px
        '20': '5rem',      // 80px
        '24': '6rem',      // 96px
        '28': '7rem',      // 112px
        '32': '8rem',      // 128px
        '36': '9rem',      // 144px
        '40': '10rem',     // 160px
        '44': '11rem',     // 176px
        '48': '12rem',     // 192px
        '52': '13rem',     // 208px
        '56': '14rem',     // 224px
        '60': '15rem',     // 240px
        '64': '16rem',     // 256px
        '72': '18rem',     // 288px
        '80': '20rem',     // 320px
        '96': '24rem'      // 384px
      },
      
      // Border Radius (Apple's rounded corners)
      borderRadius: {
        'none': '0',
        'sm': '0.25rem',   // 4px
        'DEFAULT': '0.375rem', // 6px
        'md': '0.5rem',    // 8px
        'lg': '0.75rem',   // 12px
        'xl': '1rem',      // 16px
        '2xl': '1.5rem',   // 24px
        '3xl': '2rem',     // 32px
        'full': '9999px'
      },
      
      // Box Shadows (Apple's elevation system)
      boxShadow: {
        'sm': '0 1px 2px 0 rgba(0, 0, 0, 0.05)',
        'DEFAULT': '0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px 0 rgba(0, 0, 0, 0.06)',
        'md': '0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06)',
        'lg': '0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05)',
        'xl': '0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04)',
        '2xl': '0 25px 50px -12px rgba(0, 0, 0, 0.25)',
        'inner': 'inset 0 2px 4px 0 rgba(0, 0, 0, 0.06)',
        'none': 'none',
        
        // Apple-specific shadows
        'apple-sm': '0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24)',
        'apple-md': '0 3px 6px rgba(0, 0, 0, 0.15), 0 2px 4px rgba(0, 0, 0, 0.12)',
        'apple-lg': '0 10px 20px rgba(0, 0, 0, 0.15), 0 3px 6px rgba(0, 0, 0, 0.10)',
        'apple-xl': '0 15px 25px rgba(0, 0, 0, 0.15), 0 5px 10px rgba(0, 0, 0, 0.05)',
        
        // Keyboard key shadows
        'key': '0 1px 0 rgba(0, 0, 0, 0.2), 0 0 0 1px rgba(255, 255, 255, 0.1) inset',
        'key-pressed': 'inset 0 1px 2px rgba(0, 0, 0, 0.2)'
      },
      
      // Animations and Transitions
      animation: {
        'fade-in': 'fadeIn 0.5s ease-in-out',
        'fade-in-up': 'fadeInUp 0.6s ease-out',
        'fade-in-down': 'fadeInDown 0.6s ease-out',
        'slide-in-left': 'slideInLeft 0.5s ease-out',
        'slide-in-right': 'slideInRight 0.5s ease-out',
        'bounce-gentle': 'bounceGentle 2s infinite',
        'pulse-gentle': 'pulseGentle 3s ease-in-out infinite',
        'float': 'float 3s ease-in-out infinite',
        'glow': 'glow 2s ease-in-out infinite alternate',
        'shimmer': 'shimmer 2s linear infinite'
      },
      
      keyframes: {
        fadeIn: {
          '0%': { opacity: '0' },
          '100%': { opacity: '1' }
        },
        fadeInUp: {
          '0%': { opacity: '0', transform: 'translateY(30px)' },
          '100%': { opacity: '1', transform: 'translateY(0)' }
        },
        fadeInDown: {
          '0%': { opacity: '0', transform: 'translateY(-30px)' },
          '100%': { opacity: '1', transform: 'translateY(0)' }
        },
        slideInLeft: {
          '0%': { opacity: '0', transform: 'translateX(-30px)' },
          '100%': { opacity: '1', transform: 'translateX(0)' }
        },
        slideInRight: {
          '0%': { opacity: '0', transform: 'translateX(30px)' },
          '100%': { opacity: '1', transform: 'translateX(0)' }
        },
        bounceGentle: {
          '0%, 100%': { transform: 'translateY(0)' },
          '50%': { transform: 'translateY(-10px)' }
        },
        pulseGentle: {
          '0%, 100%': { opacity: '1' },
          '50%': { opacity: '0.8' }
        },
        float: {
          '0%, 100%': { transform: 'translateY(0px)' },
          '50%': { transform: 'translateY(-10px)' }
        },
        glow: {
          '0%': { boxShadow: '0 0 5px rgba(0, 122, 255, 0.5)' },
          '100%': { boxShadow: '0 0 20px rgba(0, 122, 255, 0.8)' }
        },
        shimmer: {
          '0%': { backgroundPosition: '-200% 0' },
          '100%': { backgroundPosition: '200% 0' }
        }
      },
      
      // Backdrop Blur
      backdropBlur: {
        'xs': '2px',
        'sm': '4px',
        'DEFAULT': '8px',
        'md': '12px',
        'lg': '16px',
        'xl': '24px',
        '2xl': '40px',
        '3xl': '64px'
      },
      
      // Container Sizes
      container: {
        center: true,
        padding: {
          'DEFAULT': '1rem',
          'sm': '2rem',
          'lg': '4rem',
          'xl': '5rem',
          '2xl': '6rem'
        },
        screens: {
          'sm': '640px',
          'md': '768px',
          'lg': '1024px',
          'xl': '1280px',
          '2xl': '1536px'
        }
      }
    }
  },
  plugins: [
    // Custom plugin for Apple Keyboard+ components
    function({ addComponents, theme }) {
      addComponents({
        // Button Components
        '.btn-apple': {
          display: 'inline-flex',
          alignItems: 'center',
          justifyContent: 'center',
          padding: `${theme('spacing.3')} ${theme('spacing.6')}`,
          fontSize: theme('fontSize.base[0]'),
          fontWeight: theme('fontWeight.medium'),
          lineHeight: theme('fontSize.base[1].lineHeight'),
          borderRadius: theme('borderRadius.lg'),
          border: 'none',
          cursor: 'pointer',
          transition: 'all 0.2s ease-in-out',
          textDecoration: 'none',
          userSelect: 'none',
          '&:focus': {
            outline: 'none',
            boxShadow: `0 0 0 3px ${theme('colors.apple.blue')}40`
          }
        },
        
        '.btn-primary': {
          backgroundColor: theme('colors.apple.blue'),
          color: theme('colors.apple.white'),
          '&:hover': {
            backgroundColor: theme('colors.apple.blue-dark'),
            transform: 'translateY(-1px)',
            boxShadow: theme('boxShadow.apple-md')
          },
          '&:active': {
            transform: 'translateY(0)',
            boxShadow: theme('boxShadow.apple-sm')
          }
        },
        
        '.btn-secondary': {
          backgroundColor: theme('colors.apple.gray-100'),
          color: theme('colors.apple.gray-900'),
          '&:hover': {
            backgroundColor: theme('colors.apple.gray-200'),
            transform: 'translateY(-1px)',
            boxShadow: theme('boxShadow.apple-md')
          }
        },
        
        // Card Components
        '.card-apple': {
          backgroundColor: theme('colors.apple.white'),
          borderRadius: theme('borderRadius.2xl'),
          boxShadow: theme('boxShadow.apple-sm'),
          padding: theme('spacing.6'),
          border: `1px solid ${theme('colors.apple.gray-200')}`,
          transition: 'all 0.3s ease-in-out',
          '&:hover': {
            transform: 'translateY(-2px)',
            boxShadow: theme('boxShadow.apple-lg')
          }
        },
        
        // Glass Morphism
        '.glass': {
          backgroundColor: 'rgba(255, 255, 255, 0.1)',
          backdropFilter: 'blur(20px)',
          WebkitBackdropFilter: 'blur(20px)',
          border: '1px solid rgba(255, 255, 255, 0.2)',
          borderRadius: theme('borderRadius.2xl')
        },
        
        // Input Components
        '.input-apple': {
          width: '100%',
          padding: `${theme('spacing.3')} ${theme('spacing.4')}`,
          fontSize: theme('fontSize.base[0]'),
          lineHeight: theme('fontSize.base[1].lineHeight'),
          border: `1px solid ${theme('colors.apple.gray-300')}`,
          borderRadius: theme('borderRadius.lg'),
          backgroundColor: theme('colors.apple.white'),
          transition: 'all 0.2s ease-in-out',
          '&:focus': {
            outline: 'none',
            borderColor: theme('colors.apple.blue'),
            boxShadow: `0 0 0 3px ${theme('colors.apple.blue')}20`
          },
          '&::placeholder': {
            color: theme('colors.apple.gray-400')
          }
        },
        
        // Keyboard Key Style
        '.key': {
          display: 'inline-flex',
          alignItems: 'center',
          justifyContent: 'center',
          minWidth: theme('spacing.8'),
          height: theme('spacing.8'),
          padding: `${theme('spacing.1')} ${theme('spacing.2')}`,
          fontSize: theme('fontSize.sm[0]'),
          fontWeight: theme('fontWeight.medium'),
          backgroundColor: theme('colors.apple.key-white'),
          border: `1px solid ${theme('colors.apple.gray-300')}`,
          borderRadius: theme('borderRadius.md'),
          boxShadow: theme('boxShadow.key'),
          cursor: 'pointer',
          userSelect: 'none',
          transition: 'all 0.1s ease-in-out',
          '&:hover': {
            backgroundColor: theme('colors.apple.gray-100')
          },
          '&:active': {
            transform: 'translateY(1px)',
            boxShadow: theme('boxShadow.key-pressed')
          }
        }
      })
    },
    
    // Form styling plugin
    require('@tailwindcss/forms')({
      strategy: 'class'
    }),
    
    // Typography plugin
    require('@tailwindcss/typography'),
    
    // Aspect ratio plugin
    require('@tailwindcss/aspect-ratio')
  ],
  
  // Purge unused styles in production
  purge: {
    enabled: process.env.NODE_ENV === 'production',
    content: [
      './VoxTics/Views/**/*.{cshtml,html}',
      './VoxTics/Areas/**/*.{cshtml,html}',
      './VoxTics/wwwroot/js/**/*.js'
    ],
    options: {
      safelist: [
        // Always keep these classes
        'btn-apple',
        'btn-primary',
        'btn-secondary',
        'card-apple',
        'glass',
        'input-apple',
        'key',
        /^animate-/,
        /^transition-/,
        /^duration-/,
        /^ease-/,
        /^apple-/,
        /^system-/,
        /^label-/
      ]
    }
  }
}