$(document).ready(function () {
    $("#frmEjemplo").submit(function () {
        var serverUrl = window.location.origin;
        var SubtemaId = $("#SubtemaId").val();        
        var form = $(this);
        if (form.validate()) {
            form.ajaxSubmit({
                dataType: 'JSON',
                type: 'POST',
                url: form.attr('action'),
                success: function (r) {                    
                    if (r == "OK") {
                        LimpiarDiv_ejemplo();
                        toast_success('Datos guardados correctamente');
                        /*Actualizamos el arbol principal */                        
                        $.ajax({
                            url: serverUrl + '/Ejemploes/ArbolEjemplo',
                            type: 'GET',
                            data: {                                
                                subtemaId: SubtemaId
                            },
                            success: function (result) {                                
                                $("#div_arbol_ejemplo_" + SubtemaId).empty();
                                $("#div_arbol_ejemplo_" + SubtemaId).append(result);
                            },
                            error: function () {
                                alert("error");
                            }
                        });


                    } else {                        
                        alertSw('info', r, 'No se guardaron los datos');
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

        return false;
    })
})