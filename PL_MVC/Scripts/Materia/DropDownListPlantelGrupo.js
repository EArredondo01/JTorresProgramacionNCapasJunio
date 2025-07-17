$(document).ready(function () {

 

    $("#ddlPlantel").change(function () {

        $("#ddlGrupo").empty();

        $.ajax({
            type: 'GET',
            url: 'Materia/EstadoGetByIdPlantel',
            dataType: 'json',
            data: { IdPlantel: $("#ddlPlantel").val() },
            success: function (grupos) {
                $("#ddlGrupo").append('<option value="0">' + 'Seleccione una opción' + '</option>');
                $.each(grupos, function (i, grupos) {
                    $("#ddlGrupo").append('<option value="'
                        + grupos.IdGrupo + '">'
                        + grupos.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });


});


