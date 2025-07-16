$(document).ready(function () {

    $('#txtNombre').blur(function (e) {
        var Resultado = $(this).val()
        alert(Resultado);


    })

});

function MostrarTexto() {
    var Resultado = document.getElementById("txtNombre").value //JavaScript //Id
    var Resultado2 = $("#txtNombre").val(); //1

    alert(Resultado);
}

function GetElemets() {
    var Resultado2 = $(".form-control"); //1

}

