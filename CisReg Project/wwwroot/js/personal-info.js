
// View - PersonalInfo.cshtml

// Função para redirecionar o usuário para a página de registro de Informações Profissionais.
function redirectToRegisterProfessionalInfo() {
    window.location.href = "/register-professional-info";
}

// Função para estilizar o campo de CPF, formatando-o em "127.138.491-92".
function formatCpfInput(cpf) {
    // Remove caracteres não numéricos.
    cpf = cpf.replace(/\D/g, '');

    // Adiciona a máscara
    if (cpf.length <= 11) {
        cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
        cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
        cpf = cpf.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    }

    return cpf;
}

// Função a ser chamada em Personal Info que envia o input atual e faz a transformação.
function applyCpfMask(input) {
    // Chama a função formatCpfInput enquanto o usuário digita.
    input.value = formatCpfInput(input.value);
}

// Função para estilizar o campo de E-mail, impedindo a utilização do espaço e deixando-o apenas em letras minúsculas.
function formatEmailInput(email) {
    email = email.trim();

    email = email.toLowerCase();

    email = email.replace(/\s+/g, '');

    return email
}

// Função a ser chamada em Personal Info que envia o input atual e faz a transformação.
function applyEmailFormat(input) {
    input.value = formatEmailInput(input.value);
}

// Função que torna o password digitado visível por meio de uma troca de type (password -> text || text -> password), assim como o ícone. 
// Levemente modificado, para alterar os respectivos campos segundo o uso: Senha e Confirme a Senha.
function togglePasswordVisibility(inputId, iconId) {
    var passwordField = document.getElementById(inputId);
    var toggleIcon = document.getElementById(iconId);

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

// Função que valida o formato do valor de inserção atribuído a este campo.
function validateName(input) {
    const pattern = /^[A-Za-z\s]+$/;


    if (input.value.trim() === "" || !pattern.test(input.value)) {
        input.classList.add('input-error'); 
        input.classList.remove('input-accent');
    } else {
        input.classList.remove('input-error'); 
        input.classList.add('input-accent'); 
    }
}
