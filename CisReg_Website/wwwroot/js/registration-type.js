
// Views - Registration - Index.cshtml

// Função que verifica se o usuário selecionou algum dos três tipos de cadastro.
function validateForm() {
    const selectedType = document.querySelector('input[name="SelectedRegistrationType"]:checked');

    if (!selectedType) {
        alert("Nenhum tipo de registro selecionado.");
        return false;
    }

    const selectedValue = selectedType.value;

    if (selectedType && selectedValue === 'ProfissionalDeSaude') {
        return true;
    }
    else {
        return false;
    }

}


