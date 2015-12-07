﻿$("#sede-sao-leo").click(function () {
    var id_sede = $("#sede-sao-leo").children("input").attr("value");
    $.ajax({
        type: "GET",
        url: '/Sede/PegarAndaresDasSedes',        
        dataType: "json"
    }).done(
        function (json) {
            var options = "";
            options += '<option value="' + json[id_sede-1].Andares[0].Id + '">' + json[id_sede-1].Andares[0].Descricao + '</option>';
            $("#btn-ir").addClass("show");
            $("#dropdown-andar").addClass("show");
            $("#dropdown-andar").empty().append(options);
        }
    );
});

$("#btn-ir").click(function () {
    var descricaoAndar = $("#dropdown-andar").find(":selected").text();
    var id_sede = $("#sede-sao-leo").children("input").attr("value");
    $.ajax({
        type: "POST",
        url: '/Sede/PegarNomeSede',
        data: { idSede: id_sede },
        datatype: "json",
        success: function (data) { }
    }).done(function (nomeSede) {
        window.location.href = "/Mapa/"+nomeSede+"/" + descricaoAndar;
    }
    );
    }
);