$(function validarvoluntariosescuelas() {
    $("input[name*='ApoyoAdministrativo']").click(function () {
        var varApoyoAdministativo = $("input[name='ApoyoAdministrativo']:checked").val();
       if (varApoyoAdministativo == "2")
            $("#PanelAdministrativo").hide();
       else if (varApoyoAdministativo == "1")
            $("#PanelAdministrativo").show();
        
    });
});

$(function validarMaterial() {
    $("input[name*='TieneMaterialPedagogico']").click(function () {
        var Varlegalmente = $("input[name='TieneMaterialPedagogico']:checked").val();
        if (Varlegalmente == "2")
            $("#PanelMaterial").hide();
        else if (Varlegalmente == "1")
            $("#PanelMaterial").show();

    });
});

$(function validarcreadalegalmente() {
    $("input[name*='CreadaLegalmente']").click(function () {
        var Varlegalmente = $("input[name='CreadaLegalmente']:checked").val();
        if (Varlegalmente == "2")
            $("#PanelRegimen").hide();
        else if (Varlegalmente == "1")
            $("#PanelRegimen").show();

    });
});

$(function validarentidad() {
    $("input[name*='DependeInstitucion']").click(function () {
        var vardepende = $("input[name='DependeInstitucion']:checked").val();
        if (vardepende == "2")
            $("#panelentidad").hide();
        else if (vardepende == "1")
            $("#panelentidad").show();

    });
});

$(function validarsede() {
    $("input[name*='EsAdecuadaAcusticamente']").click(function () {
        var varsede = $("input[name='EsAdecuadaAcusticamente']:checked").val();
        if (varsede == "2")
            $("#PanelSede").hide();
        else if (varsede == "1")
            $("#PanelSede").show();

    });
});

$(function validarInternet() {
    $("input[name*='TieneAccesoInternet']").click(function () {
        var varInternet = $("input[name='TieneAccesoInternet']:checked").val();
        if (varInternet == "2")
            $("#PanelInternet").hide();
        else if (varInternet == "1")
            $("#PanelInternet").show();

    });
});

$(function validarOrganizacion() {
    $("input[name*='TieneOrganizacionComunitaria']").click(function () {
        var varorganizacion = $("input[name='TieneOrganizacionComunitaria']:checked").val();
        var varProyectos = $("input[name='TieneProyectosMusica']:checked").val();
        if (varorganizacion == "2") {
            $("#PanelOrganizacion").hide();
            $("#Panelproyectos").hide();
        }
        else if (varorganizacion == "1") {
            $("#PanelOrganizacion").show();
            $("#Panelproyectos").show();

            if (varProyectos == "1")
                $("#Panelproyectos").show();
            else
                $("#Panelproyectos").hide();
        }

        
    });
});

$(function validarProyectos() {
    $("input[name*='TieneProyectosMusica']").click(function () {
        var varProyectos = $("input[name='TieneProyectosMusica']:checked").val();
        if (varProyectos == "2")
            $("#Panelproyectos").hide();
        else if (varProyectos == "1")
            $("#Panelproyectos").show();

    });
});

$(function () {
    var varApoyoAdministativo = $("input[name='ApoyoAdministrativo']:checked").val();
    var Varlegalmente = $("input[name='CreadaLegalmente']:checked").val();
    var vardepende = $("input[name='DependeInstitucion']:checked").val();
    var varsede = $("input[name='EsAdecuadaAcusticamente']:checked").val();
    var varInternet = $("input[name='TieneAccesoInternet']:checked").val();
    var varorganizacion = $("input[name='TieneOrganizacionComunitaria']:checked").val();
    var varProyectos = $("input[name='TieneProyectosMusica']:checked").val();
    var varMaterial = $("input[name='TieneMaterialPedagogico']:checked").val();

    if (varorganizacion == "2"){
        $("#PanelOrganizacion").hide();
        $("#Panelproyectos").hide();
    }
    else if (varorganizacion == "1")
    {
        $("#PanelOrganizacion").show();
        if (varProyectos == "1")
            $("#Panelproyectos").show();
        else 
            $("#Panelproyectos").hide();
    }

    
    if (varsede == "2")
        $("#PanelSede").hide();
    else if (varsede == "1")
        $("#PanelSede").show();

    if (varApoyoAdministativo == "2")
        $("#PanelAdministrativo").hide();
    else if (varApoyoAdministativo == "1")
        $("#PanelAdministrativo").show();

    if (Varlegalmente == "2")
        $("#PanelRegimen").hide();
    else if (Varlegalmente == "1")
        $("#PanelRegimen").show();

    if (vardepende == "2")
        $("#panelentidad").hide();
    else if (vardepende == "1")
        $("#panelentidad").show();

    if (varInternet == "2")
        $("#PanelInternet").hide();
    else if (varInternet == "1")
        $("#PanelInternet").show();

    if (varMaterial == "2")
        $("#PanelMaterial").hide();
    else if (varMaterial == "1")
        $("#PanelMaterial").show();
    
});

function pintarInformacionDocentes() {
    console.log("Input");
    Morris.Donut({
        element: 'InformacionDocentesD3',
        data: [
            { label: "Voluntarios", value: $(InformacionDocentesArray[0]).val() },
            { label: "Laboral", value: $(InformacionDocentesArray[1]).val() },
            { label: "Por honorarios", value: $(InformacionDocentesArray[2]).val() },
            { label: "OPS", value: $(InformacionDocentesArray[3]).val() },
        ],
        colors: [paletaInformacionDocentes[0], paletaInformacionDocentes[1], paletaInformacionDocentes[2], paletaInformacionDocentes[3]],
        resize: true
    });
}
function pintarInformacionDocentesSpinnerValue() {
    totalizarInformacionDocentes();
    console.log("Spinner");
    $("#InformacionDocentesD3").html(""); // Reinicia la gráfica
    /* Graficar la dona cuando se usa el spiner */
    Morris.Donut({
        element: 'InformacionDocentesD3',
        data: [
            { label: "Voluntarios", value: $(InformacionDocentesArray[0]).val() },
            { label: "Laboral", value: $(InformacionDocentesArray[1]).val() },
            { label: "Por honorarios", value: $(InformacionDocentesArray[2]).val() },
            { label: "OPS", value: $(InformacionDocentesArray[3]).val() },
        ],
        colors: [paletaInformacionDocentes[0], paletaInformacionDocentes[1], paletaInformacionDocentes[2], paletaInformacionDocentes[3]],
        resize: true
    });
}

// pintarlabelColor();

function pintarlabelColor() {

    var labelArray = ["Voluntarios", "ContratoLaboral", "ContratoHonorario", "OrdenPrestacionServicios"];
    var labelArrayLength = labelArray.length;
    for (var i = 0; i < labelArrayLength; i++) {
        var div = document.createElement("div");
        div.style.width = "10px";
        div.style.height = "10px";
        div.style.background = paletaInformacionDocentes[i];
        div.style.float = "left";
        div.style.margin = "4px 5px";
        document.getElementById('label' + labelArray[i]).appendChild(div);
    }
}


function totalizarInformacionDocentes() {
    var tot = 0;
    for (var i = 0; i < InformacionDocentesLength; i++) {
        console.log($(InformacionDocentesArray[i]).val());
        if (parseInt($(InformacionDocentesArray[i]).val()))
            tot += parseInt($(InformacionDocentesArray[i]).val());
    }
    $("#labelTotalInformacionDocentes").html(tot);
}

function HabilitarDeshabilitarPasos() {

    var id = $("#EscuelaId").val();
  
    $.ajax({
        type: 'POST',
        url: '/EscuelasMusica/PasoActual',
        dataType: 'json',
        data: { Id: id },
        success: function (data) {

            switch (data) {
                case 7:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("exito");
                    $("#step5").addClass("exito");
                    $("#step6").addClass("exito");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(95 + "%").attr('aria-valuenow', 95);
                    break;
                case 61:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("exito");
                    $("#step5").addClass("exito");
                    $("#step6").addClass("exito");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(90 + "%").attr('aria-valuenow', 90);
                    break;
                case 6:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("exito");
                    $("#step5").addClass("exito");
                    $("#step6").addClass("exito");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(85 + "%").attr('aria-valuenow', 85);
                    break;
                case 5:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("exito");
                    $("#step5").addClass("exito");
                    $("#step6").addClass("disabled");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(70 + "%").attr('aria-valuenow', 70);
                    break;
                case 4:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("exito");
                    $("#step5").addClass("disabled");
                    $("#step6").addClass("disabled");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(40 + "%").attr('aria-valuenow', 40);
                    break;
                case 3:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("exito");
                    $("#step4").addClass("disabled");
                    $("#step5").addClass("disabled");
                    $("#step6").addClass("disabled");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(20 + "%").attr('aria-valuenow', 20);
                    break;
                case 2:
                    $("#step1").addClass("exito");
                    $("#step2").addClass("exito");
                    $("#step3").addClass("disabled");
                    $("#step4").addClass("disabled");
                    $("#step5").addClass("disabled");
                    $("#step6").addClass("disabled");
                    $("#step7").addClass("exito");
                    $('.barra_pasoapaso').width(17 + "%").attr('aria-valuenow', 17);
                    break;
                case 1: //El primer paso se divide en 4 secciones
                    $("#step1").addClass("exito");
                    $("#step2").addClass("disabled");
                    $("#step3").addClass("disabled");
                    $("#step4").addClass("disabled");
                    $("#step5").addClass("disabled");
                    $("#step6").addClass("disabled");
                    $("#step7").addClass("exito");
                
                    $('.barra_pasoapaso').width(5 + "%").attr('aria-valuenow', 5);
                    break;
                
             
            }
        }
    })
}

function ValidaSoloNumeros() {
    console.log("ValidaSoloNumeros");
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
}



function ValidaAlfanumericos() {
    if (this.value.match(/[^a-zA-Z0-9 ]/g)) {
        this.value = this.value.replace(/[^a-zA-Z0-9 ]/g, '');
    } else {

        alert("Sólo los caracteres alfanuméricos se les permite");
    }

}





