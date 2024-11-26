
// Views - Login - Index.cshtml

// Função listener para verificar e adicionar o elemento de id 'errorToast' e fazer ele desaparecer.
document.addEventListener('DOMContentLoaded', function () {
    const errorAlert = document.getElementById('errorAlert');
    errorAlert.style.opacity = 1;

    let alertOpacity = parseFloat(errorAlert.style.opacity);

    function fadeAlert() {
        alertOpacity -= 0.03;
        errorAlert.style.opacity = alertOpacity;

        if (alertOpacity <= 0) {
            errorAlert.style.display = 'none';
        } else {
            requestAnimationFrame(fadeAlert);
        }
    }

    setTimeout(fadeAlert, 2000);

});

// Função que torna o password digitado visível por meio de uma troca de type (password -> text || text -> password), assim como o ícone.
function togglePasswordVisibility() {
    var passwordField = document.getElementById('password');
    var toggleIcon = document.getElementById('toggle-icon');
    if (passwordField.type === 'password') {
        passwordField.type = 'text';
        toggleIcon.classList.remove('fa-eye');
        toggleIcon.classList.add('fa-eye-slash');
    } else {
        passwordField.type = 'password';
        toggleIcon.classList.remove('fa-eye-slash');
        toggleIcon.classList.add('fa-eye');
    }
}


// Função para estilizar o campo de E-mail, impedindo a utilização do espaço e deixando-o apenas em letras minúsculas.
function formatEmailInputAtLogin(email) {
    email = email.trim();

    email = email.toLowerCase();

    email = email.replace(/\s+/g, '');

    return email
}

// Função a ser chamada em Personal Info que envia o input atual e faz a transformação.
function applyEmailFormatAtLogin(input) {
    input.value = formatEmailInputAtLogin(input.value);
}

// Função que valida o formato do valor de inserção atribuído a este campo.
function validateFieldInputAtLogin(input) {
    input.classList.remove('input-error');
    input.classList.remove('input-accent');

    if (!input.checkValidity()) {
        input.classList.add('input-error');
    } else {
        input.classList.add('input-accent');
    }
}

document.body.classList.add('no-scroll');











