
// Views - Registration - PersonalInfo.cshtml

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

function validateCPF(input, errorMessageText) {

    const span = document.querySelector(`#${input.id}-error`);
    const isEmpty = input.value.trim() === '';

    let cpf = input.value.replace(/\D/g, '');

    input.classList.remove('input-error', 'input-accent');

    if (isEmpty) {
        input.classList.add('input-error');
        span.classList.add('hidden');
        span.innerHTML = "";
        return;
    }

    if (
        cpf === "00000000000" || cpf === "11111111111" ||
        cpf === "22222222222" || cpf === "33333333333" ||
        cpf === "44444444444" || cpf === "55555555555" ||
        cpf === "66666666666" || cpf === "77777777777" ||
        cpf === "88888888888" || cpf === "99999999999" ||
        cpf.length !== 11
    ) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = errorMessageText;
        return;
    }

    let sm = 0;

    for (let i = 0; i < 9; i++) {
        sm += (parseInt(cpf.charAt(i), 10) * (10 - i));
    }
    let primDigit = 11 - (sm % 11);
    if (primDigit >= 10) {
        primDigit = 0;
    }

    // Verifica se o primeiro dígito verificador é igual ao informado no CPF.
    if (primDigit !== parseInt(cpf.charAt(9), 10)) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = errorMessageText;
        return;
    }

    // Calcula o segundo dígito verificador
    sm = 0;
    for (let i = 0; i < 10; i++) {
        sm += (parseInt(cpf.charAt(i), 10) * (11 - i));
    }
    let segundDigit = 11 - (sm % 11);
    if (segundDigit >= 10) {
        segundDigit = 0;
    }

    // Verifica se o segundo dígito verificador é igual ao informado no CPF.
    if (segundDigit !== parseInt(cpf.charAt(10), 10)) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = errorMessageText;
        return;
    }

    // CPF é válido.
    input.classList.add('input-accent');
    span.classList.add('hidden');
}


// Função que valida o formato do valor de inserção atribuído a este campo, exibindo/removendo textos e efeitos de erro.
function validateFieldInput(input, errorMessageText) {

    const span = document.querySelector(`#${input.id}-error`);

    input.classList.remove('input-error', 'input-accent'); 

    const isValid = input.checkValidity();
    const isEmpty = input.value.trim() === '';

    // Verifica a validade do input de acordo com o pattern.
    if (!isValid) {
        input.classList.add('input-error'); 
        span.classList.remove('hidden'); 
        span.innerHTML = errorMessageText; 
    } 
    else {
        input.classList.add('input-accent'); 
        span.classList.add('hidden'); 
        span.innerHTML = ""; 
    }
    if (isEmpty) {
        input.classList.add('input-error');
        span.classList.add('hidden'); 
        span.innerHTML = ""; 
    }
}

function validateEmail(input, errorMessageText) {

    const email = input.value.trim();
    const emailPattern = /^[^\s@]+@[^\s@]+\.[a-zA-Z]{2,}$/;

    const span = document.querySelector(`#${input.id}-error`);

    input.classList.remove('input-error', 'input-accent');

    const isEmpty = email == '';

    const validTLDs = ['com', 'org', 'net', 'edu', 'gov', 'br', 'co', 'uk', 'de', 'fr', 'us', 'ca', 'au', 'jp'];

    if (isEmpty) {
        input.classList.add('input-error');
        span.classList.add('hidden');
        span.innerHTML = "";
        return;
    }

    if (!emailPattern.test(email)) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = errorMessageText;
        return;
    }

    // Verifica se o domínio possui um TLD válido
    const domain = email.split('@')[1];
    const tld = domain.split('.').pop(); 

    if (!validTLDs.includes(tld.toLowerCase())) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = "Por favor, insira um domínio válido.";
        return;
    }

    input.classList.add('input-accent');
    span.classList.add('hidden');
    span.innerHTML = "";


}

// Função que valida a data inserida, verificando se o usuário não inseriu informações falsas.
function validateAge(input, errorMessageText) {

    const span = document.querySelector(`#${input.id}-error`);

    input.classList.remove('input-error', 'input-accent');

    const isEmpty = input.value.trim() === '';

    const birthDate = new Date(input.value);
    const currentDate = new Date();

    if (isEmpty) {
        input.classList.add('input-error');
        span.classList.add('hidden');
        span.innerHTML = "";
        return;
    }

    let age = currentDate.getFullYear() - birthDate.getFullYear();
    const monthDifference = currentDate.getMonth() - birthDate.getMonth();

    if (monthDifference < 0 || (monthDifference === 0 && currentDate.getDate() < birthDate.getDate())) {
        age--;
    }

    if (birthDate.getFullYear() > currentDate.getFullYear()) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = "Por favor, insira um ano válido.";
        return;
    }

    if (age < 18) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = "A idade não pode ser inferior a 18 anos.";
        return;
    } 

    if (age > 130) {
        input.classList.add('input-error');
        span.classList.remove('hidden');
        span.innerHTML = errorMessageText;
        return;
    }

    input.classList.add('input-accent');
    span.classList.add('hidden');
    span.innerHTML = "";
    

}

// Função que verifica se o campo (Senha) e o (Confirmar Senha) tem os inputs equivalentes.
function verifyIfPasswordsMatch(input, errorMessageText) {

    const confirmPassSpan = document.querySelector(`#${input.id}-error`);

    const passwordInputValue = document.querySelector(`#password`).value;
    const confirmPasswordInputValue = input.value;

    input.classList.remove('input-error', 'input-accent');

    const isEmpty = confirmPasswordInputValue.trim() === '';

    if (isEmpty) {
        input.classList.add('input-error')
        confirmPassSpan.classList.add('hidden');
        confirmPassSpan.innerHTML = "";
        return;
    }

    if (passwordInputValue !== confirmPasswordInputValue) {
        input.classList.add('input-error');
        confirmPassSpan.classList.remove('hidden');
        confirmPassSpan.innerHTML = errorMessageText;
    } else {
        input.classList.add('input-accent');
        confirmPassSpan.classList.add('hidden');
        confirmPassSpan.innerHTML = "";
    }
}


