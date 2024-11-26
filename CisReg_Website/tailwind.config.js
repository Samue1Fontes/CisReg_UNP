/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml',
    ],
    safelist: [
        'input-error',
        'input-accent',
        'radio-sucess',
    ],

    theme: {
        extend: {

            // Cores a serem utilizadas no projeto
            colors: {

                // Padroes de verde
                customGreen: {
                    light: '#57BE93',
                    default: '#059C7B',
                    dark: '#074340',
                },

                // Padrões de verde (hover effect)
                onHoverGreen: {
                    on_hover_light: '#40a57b',
                    on_hover_default: '#05ad89',
                },

                // Padroes de cinza
                customGrey: {
                    light: '#F7F7F7',
                    default: '#828282',
                    dark: '#4F4F4F',
                },

                // Padrões de vermelho (error)
                customRed: {
                    default: '#E60000',
                },
            },

            aspectRatio: {
                // Circulos
                'circle': '1 / 1',
            },

            width: {

                // Circulos
                '61-rem': '61rem',
                '125-rem': '125rem',

                // Formulario de Login
                '394-px': '394px',
                '360-px': '360px',

                // Titulo do login
                '5-rem': '5.5rem',

                // Campos de Input
                '360-px': '360px',
                '22-px': '22px',

                // Campos de Seleção (Radio)
                '321-px': '321px',

                // Error Alert
                '100-px': '300px',

            },

            height: {

                // Circulos
                '61-rem': '61rem',
                '125-rem': '125rem',

                // Formulário de Login
                '474-px': '474px',

                // Formulário de Registro
                '730-px': '730px',
                '530-px': '530px',
                '40-px': '40px',

                // Botao "Entrar"
                'entrar-height-px': '40px',

                // Campos de Seleção (Radio)
                '44-px': '44px',

            },

            backgroundImage: {

                // Circulos
                'green-gradient': 'linear-gradient(180deg, #059C7B 0%, #02362B 100%)',
            },

            borderRadius: {
                // Formulario de Login
                'lg-border': '0.5rem',

                // Circulos
                'full': '9999px',
            },

            // Posicionamento dos elementos na tela
            inset: {
                // Primeiro Circulo
                'minus-133-px': '-133px',
                'minus-323-px': '-323px',

                // Segundo Circulo
                'minus-267-px': '-267px',
                '294-px': '294px',


                // Formulario de Login
                '170-px': '170px',

                // Titulo do Login
                '26-px': '26px',
                '100-px': '-100px',

                // UNP Logo
                '150-px': '150px',
                '50-px': '50px',

                // Formulario de Informacoes Pessoais
                '40-px': '120px',

                // Range de cor (background)
                '5-px': '-10px',
                '10-px': '10px',

            },

            scale: {
                '90': '0.9',
                '110': '1.1',
                '125': '1.25',
                '150': '1.5',
                '200': '2.0',
            },

            boxShadow: {
                // Formulario de Login
                'login': '0px 4px 4px 0px rgba(0, 0, 0, 0.25)',
            },

            textAlign: {
                // Titulo do Login
                'center': 'center',
                'left': 'left',
                'right': 'right',
            },

            textDecoration: {
                // Link do Esqueceu a Senha 
                'underline': 'underline',
            },

            fontFamily: {
                // Titulo do Login
                'poppins': ['Poppins', 'sans-serif'],
            },

            fontSize: {
                'xs': '0.75rem',
                'sm': '0.875rem',
                'base': '1rem',

                // Titulo do Login
                '4x1': '2.25rem',
            },

            fontWeight: {
                'normal': '400',

                // Titulo do Login
                'bold': '700'
            },

            lineHeight: {
                'leading-4': '1rem',

                'personalized': '1.4rem',

                // Titulo do Login
                'normal': '1.5'
            },

            padding: {
                // Formulario de Login
                '4': '1rem',
                '8': '2rem',
            },

            // Responsividade da tela relativo ao form de login
            transform: ['responsive'],
            translate: {
                '1/2': '50%',
            },

            // Responsividade da tela relativo ao form de login
            // custom-lg (1500px) padrões serão definidos quando a tela for igual ou maior a 1500px
            // custom-sm' (640px) padrões serão definidos quando a tela for igual ou maior a 640px
            screens: {
                'custom-lg': '1500px',
                'custom-sm': '640px',
            },

            zIndex: {
                'z-10': '10',
                'z-20': '20',
            },
        },
    },
    plugins: [
        require('@tailwindcss/aspect-ratio'),
        require('daisyui'),

        function ({ addComponents }) {
            addComponents({
                '.input-accent': {
                    '--tw-border-opacity': '1',
                    'border-color': 'var(--fallback-a, oklch(0 0 0 / var(--tw-border-opacity)))',
                },
                '.input-accent:focus, .input-accent:focus-within': {
                    '--tw-border-opacity': '1',
                    'border-color': 'var(--fallback-a, oklch(var(--a) / var(--tw-border-opacity)))',
                    'outline': 'none',
                },
                '.input-error': {
                    '--tw-border-opacity': '1',
                    'border-color': '#E60000',
                },
                '.input-error:focus, .input-error:focus-within': {
                    '--tw-border-opacity': '1',
                    'border-color': '#E60000',
                    'outline': 'none',
                },
                '.select': {
                    'height': 'unset',
                    'min-height': '0',
                    'font-size': 'unset',
                    'line-height': '1.5',
                },
                '.select-accent': {
                    '--tw-border-opacity': '1',
                    'border-color': 'var(--fallback-a, oklch(0 0 0 / var(--tw-border-opacity)))',
                },
                '.select-accent:focus': {
                    '--tw-border-opacity': '1',
                    'border-color': 'var(--fallback-a, oklch(var(--a) / var(--tw-border-opacity)))',
                    'outline': 'none',
                },
                '.range': {
                    ' --range-shdw': '#57BE93',
                    'width': '40%',
                },
                '.range:focus-visible::-webkit-slider-thumb': {
                    ' --focus-shadow': 'box-shadow: 0 0 0 6px white inset, 0 0 0 2rem var(--range-shdw) inset',

                },
            })
        },
    ],
}

