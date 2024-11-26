
// Views - Registration - ProfessionalInfo.cshtml

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

