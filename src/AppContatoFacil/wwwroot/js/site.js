// --> Função executada quando o DOM estiver completamente carregado
$(document).ready(function () {
    // Inicializa o DataTable
    $('#contatoTable').DataTable({
        // lengthMenu: [5, 10, 25, 50, { label: 'Todos', value: -1 }],
        lengthMenu: [5, 10, 25, 50, { label: 'Todos', value: 99999999999999999999 }],
        pageLength: 5,
        language: {
            url: '//cdn.datatables.net/plug-ins/2.3.2/i18n/pt-BR.json',
            paginate: {
                first: '<i class="fas fa-angle-double-left"></i>',
                previous: '<i class="fas fa-angle-left"></i>',
                next: '<i class="fas fa-angle-right"></i>',
                last: '<i class="fas fa-angle-double-right"></i>'
            }
        }
    });
});

// --> Função para esconder alertas após 4 segundos
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