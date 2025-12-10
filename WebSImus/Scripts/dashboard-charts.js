/**
 * Dashboard Charts - Configuración de gráficos para el dashboard
 * Versión moderna con estilos actualizados
 */

// Configuración común para todos los gráficos
const chartConfig = {
    colors: ['#4361ee', '#3f37c9', '#4895ef', '#4cc9f0', '#7209b7', '#f72585', '#b5179e', '#560bad'],
    gridTextColor: '#6c757d',
    gridTextSize: '11px',
    resize: true,
    hideHover: 'auto',
    xLabelAngle: 30,
    barSizeRatio: 0.4,
    barGap: 2,
    formatter: function (value) { return value + (this.type === 'donut' ? '%' : ''); }
};

// Inicialización de todos los gráficos
$(document).ready(function () {
    initMainCharts();
    initSecondaryCharts();
    initReportCharts();
});


// Asignar eventos a todos los botones de fullscreen
document.addEventListener('DOMContentLoaded', function () {
    // Configurar eventos para los botones de expandir
    document.querySelectorAll('.panel-fullscreen').forEach(button => {
        button.addEventListener('click', function (e) {
            e.preventDefault();
            const card = this.closest('.card');
            toggleFullscreen(card);

            // Redimensionar gráficos al cambiar tamaño
            setTimeout(() => {
                window.dispatchEvent(new Event('resize'));
            }, 300);
        });
    });

    // Manejar cambio de fullscreen
    document.addEventListener('fullscreenchange', function () {
        if (!document.fullscreenElement) {
            document.querySelectorAll('.card.fullscreen').forEach(card => {
                card.classList.remove('fullscreen');
            });
        }
    });
});


// Gráficos principales
function initMainCharts() {
    // Limpiar gráficos antes de volver a renderizar
    $('#dashboard-donut-1').empty();
    $('#dashboard-donut-2').empty();
    $('#dashboard-bar-1').empty();

    // Gráfico 1 - Escuelas por departamento (Bar Chart)
    Morris.Bar({
        element: 'dashboard-donut-1',
        xkey: 'label',
        ykeys: ['value'],
        labels: ['Cantidad'],
        data: $.parseJSON(Graph()),
        barColors: [chartConfig.colors[0]],
        gridTextColor: chartConfig.gridTextColor,
        gridTextSize: chartConfig.gridTextSize,
        hideHover: chartConfig.hideHover,
        xLabelAngle: chartConfig.xLabelAngle,
        barSizeRatio: chartConfig.barSizeRatio,
        barGap: chartConfig.barGap
    });

    // Gráfico 2 - Naturaleza de escuelas (Donut Chart)
    Graphescuelas(function (data) {
        Morris.Donut({
            element: 'dashboard-donut-2',
            data: data,
            colors: chartConfig.colors,
            formatter: chartConfig.formatter
        });
    });

    // Gráfico 3 - Prácticas musicales (Bar Chart)
    Morris.Bar({
        element: 'dashboard-bar-1',
        xkey: 'label',
        ykeys: ['value'],
        labels: ['Cantidad'],
        data: $.parseJSON(GraphPracticaMusical()),
        barColors: function (row, series, type) {
            const practices = {
                "Bandas": chartConfig.colors[0],
                "Músicas Tradicionales": chartConfig.colors[1],
                "Teatro": chartConfig.colors[2],
                "Coros": chartConfig.colors[3],
                "Orquestas Sinfónicas": chartConfig.colors[4]
            };
            return practices[row.label] || chartConfig.colors[5];
        },
        gridTextColor: chartConfig.gridTextColor,
        gridTextSize: chartConfig.gridTextSize,
        xLabelAngle: chartConfig.xLabelAngle
    });
}




// Gráficos secundarios
function initSecondaryCharts() {
    $('#dashboard-donut-10').empty();
    $('#dashboard-donut-11').empty();
    $('#dashboard-donut-12').empty();

    // Estado de sostenibilidad
    Morris.Donut({
        element: 'dashboard-donut-10',
        data: $.parseJSON(GetEscConsolidacion()),
        colors: chartConfig.colors,
        formatter: chartConfig.formatter
    });

    // Nivel educativo docentes
    Morris.Donut({
        element: 'dashboard-donut-11',
        data: $.parseJSON(GetProfesoresDpto()),
        colors: chartConfig.colors,
        formatter: chartConfig.formatter
    });

    // Familia instrumental
    Morris.Donut({
        element: 'dashboard-donut-12',
        data: $.parseJSON(GetDotacionInsDpto()),
        colors: chartConfig.colors,
        formatter: chartConfig.formatter
    });
}


// Gráficos de reportes
function initReportCharts() {
    $('#dashboard-donut-5').empty();
    $('#dashboard-donut-6').empty();
    $('#dashboard-donut-7').empty();
    $('#dashboard-donut-8').empty();
    $('#dashboard-donut-9').empty();

    // Rangos de edad
    Morris.Donut({
        element: 'dashboard-donut-5',
        data: $.parseJSON(Graphedades()),
        colors: chartConfig.colors,
        formatter: chartConfig.formatter
    });

    // Minoría étnica
    Morris.Bar({
        element: 'dashboard-donut-6',
        xkey: 'label',
        ykeys: ['value'],
        labels: ['Cantidad'],
        data: $.parseJSON(GrapheEtnia()),
        barColors: chartConfig.colors,
        gridTextColor: chartConfig.gridTextColor,
        gridTextSize: chartConfig.gridTextSize,
        xLabelAngle: chartConfig.xLabelAngle
    });

    // Género
    Morris.Donut({
        element: 'dashboard-donut-7',
        data: $.parseJSON(GrapheSexo()),
        colors: [chartConfig.colors[0], chartConfig.colors[5]],
        formatter: chartConfig.formatter
    });

    // Cobertura territorial
    Morris.Bar({
        element: 'dashboard-donut-8',
        xkey: 'label',
        ykeys: ['value'],
        labels: ['Cantidad'],
        data: $.parseJSON(GrapheArea()),
        barColors: [chartConfig.colors[0], chartConfig.colors[3]],
        gridTextColor: chartConfig.gridTextColor,
        gridTextSize: chartConfig.gridTextSize
    });

    // Condiciones especiales
    Morris.Donut({
        element: 'dashboard-donut-9',
        data: $.parseJSON(GraphCondiesp()),
        colors: [chartConfig.colors[6], chartConfig.colors[5], chartConfig.colors[2]],
        formatter: chartConfig.formatter
    });
}


/****************************************************
 * Funciones AJAX para obtener datos de los gráficos *
 ****************************************************/

function Graph() {
    return fetchData('/Inicio/GetPiechartData');
}

function Graphescuelas(callback) {
    $.ajax({
        type: 'POST',
        url: '/Inicio/GetEscueltasTipo?_=' + new Date().getTime(),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            callback(result); // devolvemos los datos
        },
        error: function (xhr, status, error) {
            console.error('Error cargando escuelas tipo:', error);
            callback([{ label: 'Error', value: 100 }]);
        }
    });
}





function GraphPracticaMusical() {
    return fetchData('/Inicio/GetEscPracticaMusical');
}

function Graphedades() {
    return fetchData('/Inicio/GetEscEdades');
}

function GrapheEtnia() {
    return fetchData('/Inicio/GetEscEtnia');
}

function GrapheSexo() {
    return fetchData('/Inicio/GetEscEtniSEXO');
}

function GrapheArea() {
    return fetchData('/Inicio/GetEscArea');
}

function GraphCondiesp() {
    return fetchData('/Inicio/GetEscCondiesp');
}

function GetEscConsolidacion() {
    return fetchData('/Inicio/GetEscConsolidacion');
}

function GetProfesoresDpto() {
    return fetchData('/Inicio/GetProfesoresDpto');
}

function GetDotacionInsDpto() {
    return fetchData('/Inicio/GetDotacionInsDpto');
}

// Función genérica para obtener datos
function fetchData(url) {
    var data = "";
    $.ajax({
        type: 'POST',
        url: url + "?_=" + new Date().getTime(),
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            data = result;
        },
        error: function (xhr, status, error) {
            console.error('Error fetching data from ' + url + ':', error);
            // Mostrar mensaje de error en el gráfico
            data = [{ label: 'Error', value: 100 }];
        }
    });
    return data;
}

function refreshDashboard() {
    showFullScreenLoader();

    setTimeout(() => {
        refreshWidgets();
        initMainCharts();
        initSecondaryCharts();
        initReportCharts();
        hideFullScreenLoader();
    }, 500); // da un pequeño delay para mejor UX visual
}





function refreshWidgets() {
    $('#dashboard-overlay').fadeIn(200); // Mostrar el overlay

    $.ajax({
        url: '/Inicio/GetWidgetData',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('.cant-agente').text(parseInt(data.cantAgente).toLocaleString());
            $('.total-comunitaria').text(parseInt(data.totalComunitaria).toLocaleString());
            $('.entdependeotra').text(parseInt(data.entdependeotra).toLocaleString());
            $('.cant-entidad').text(parseInt(data.cantEntidad).toLocaleString());
            $('.total-estudiantes').text(parseInt(data.totalEstudiantes).toLocaleString());
            $('.total-profesores').text(parseInt(data.totalProfesores).toLocaleString());
            $('.estd-escenarios').text(parseInt(data.EstdEscenarios).toLocaleString());
        },
        error: function (err) {
            console.error('Error al actualizar widgets:', err);
            alert("Hubo un error al actualizar los datos del dashboard.");
        },
        complete: function () {
            $('#dashboard-overlay').fadeOut(200); // Ocultar el overlay
        }
    });
}

function showFullScreenLoader() {
    if ($('#fullscreen-loader').length === 0) {
        $('body').append(`
            <div id="fullscreen-loader" style="position: fixed; top: 0; left: 0; width: 100vw; height: 100vh; background: rgba(255,255,255,0.85); z-index: 9999; display: flex; align-items: center; justify-content: center;">
                <div style="text-align: center; font-size: 1.5rem; color: #4b3c8c;">
                    <i class="fa fa-spinner fa-spin fa-3x"></i>
                    <div style="margin-top: 10px;">Actualizando datos del dashboard...</div>
                </div>
            </div>
        `);
    }
    $('#fullscreen-loader').fadeIn(200);
}

function hideFullScreenLoader() {
    $('#fullscreen-loader').fadeOut(200, function () {
        $(this).remove();
    });
}



$(document).on('click', '#refresh-data', function () {
    refreshDashboard();
});

$.ajax({
    url: '/Escuelas/CambiarTipo',
    type: 'POST',
    data: JSON.stringify({ id: escuelaId, nuevoTipo: tipo }),
    contentType: "application/json; charset=utf-8",
    success: function (res) {
        // ¡Refrescar el dashboard!
        refreshDashboard();
    },
    error: function (err) {
        console.error('Error al cambiar el tipo de escuela:', err);
    }
});
