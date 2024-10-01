/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.razor',
        './wwwroot/**/*.html',
        './**/*.cshtml'
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
                '61': '61rem',

                // Formulario de Login
                '394': '394px',

                // Titulo do login
                '5': '5.5rem',

                // Campos E-mail & Senha 
                '53': '53px',
                '22': '22px',

                // Botao "Entrar"
                'entrar-width': '352px',

            },

            height: {
                // Circulos
                '61': '61rem',

                // Formulirio de Login
                '474': '474px',

                // Botao "Entrar"
                'entrar-height': '40px',
            },

            backgroundImage: {

                // Circulos
                'green-gradient': 'linear-gradient(180deg, #059C7B 0%, #02362B 100%)',
            },

            borderRadius: {
                // Formulario de Login
                'lg': '0.5rem',

                // Circulos
                'full': '9999px',
            },

            // Posicionamento dos elementos na tela
            inset: {
                // Primeiro Circulo
                '597': '597px',
                '133': '-133px',
                '323': '-323px',
                '456': '456px',

                // Segundo Circulo
                '731': '731px',
                '267': '-267px',
                '294': '294px',
                '161': '-161px',

                // Formulario de Login
                '170': '170px',

                // Titulo do Login
                '152': '152px',
                '26': '26px',


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

            margin: {
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
            },
        },
    },
    plugins: [
        require('@tailwindcss/aspect-ratio'),
        require('daisyui')
    ],
}
