/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.razor',
        './wwwroot/**/*.html',
        './**/*.cshtml'
    ],
    safelist: [
        'input-error',
        'input-accent',
        'radio',
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

                // Padroes de cinza
                customGrey: {
                    light: '#F7F7F7',
                    default: '#828282',
                    dark: '#4F4F4F',
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

                // Titulo do login
                '5-rem': '5.5rem',

                // Campos de Input
                '360-px': '360px',
                '22-px': '22px',

                // Campos de Seleção (Radio)
                '321-px': '321px',

            },

            height: {

                // Circulos
                '61-rem': '61rem',
                '125-rem': '125rem',

                // Formulário de Login
                '474-px': '474px',

                // Formulário de Registro
                '712-px': '712px',
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

                // UNP Logo
                '150-px': '150px',
                



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
            screens: {
                'custom-lg': '1500px',
            },

            zIndex: {
                'z-10': '10',
                'z-20': '20',
            },
        },
    },
    plugins: [
        require('@tailwindcss/aspect-ratio'),
        require('daisyui')
    ],
}
