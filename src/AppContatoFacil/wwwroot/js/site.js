// Espera o DOM carregar
document.addEventListener("DOMContentLoaded", function () {
    // Seleciona todos os alerts
    const alerts = document.querySelectorAll('.alert');

    alerts.forEach(function (alert) {
        // Espera 4 segundos e depois esconde o alert
        setTimeout(function () {
            alert.classList.remove('show');
            alert.classList.add('fade');
            // Remove do DOM após a transição
            setTimeout(() => alert.remove(), 500);
        }, 4000);
    });
});