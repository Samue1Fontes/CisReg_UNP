
// View - Login.cshtml

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

// Função para redirecionar o usuário para a página de registro de Informações Pessoais.
function redirectToRegisterPersonalInfo() {
    window.location.href = "/register-personal-info";
}



