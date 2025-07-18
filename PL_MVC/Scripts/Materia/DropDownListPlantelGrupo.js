$(document).ready(function () {
    $("#ddlPlantel").change(function () {
        $("#ddlGrupo").empty();
        $.ajax({
            type: 'GET',
            url: 'EstadoGetByIdPlantel',
            dataType: 'json',
            data: { IdPlantel: $("#ddlPlantel").val() },
            success: function (grupos) {
                $("#ddlGrupo").append('<option value="0">' + 'Seleccione un Grupo' + '</option>'); // Agregar nueva opcion a dropdownlist
                $.each(grupos.Objects, function (i, grupo) { // iteramos los valores con foreach
                    $("#ddlGrupo").append('<option value="'  // agregar las opciones que tengamos
                        + grupo.IdGrupo + '">'
                        + grupo.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });


    $("#ddlMunicipio").change(function () {
        // EpeticionAJAX
        // lenar las colonias
    })


});


