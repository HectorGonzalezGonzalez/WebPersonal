$(document).ready(function () {
    $("#frmExampleDet").submit(function () {       
        var serverUrl = window.location.origin;
        var EjemploId = $("#EjemploId").val();
        var form = $(this);
        var code = $("#Codigo").val();
        if (code == "") {            
            $("#LblCodeError").html("El codigo es requerido");
        }else if (form.validate()) {
            form.ajaxSubmit({
                dataType: 'JSON',
                type: 'POST',
                url: form.attr('action'),
                success: function (r) {                    
                    if (r == "OK") {
                        LimpiarDiv_ejemplo();
                        toast_success('Datos guardados correctamente');
                    /*Actualizamos el arbol principal */
                        //ListaEjemploDetalle(int idEjemplo,int id)
                        $.ajax({
                            url: serverUrl + '/EjemploDetalles/ListaEjemploDetalle',
                            type: 'GET',
                            data: {                                
                                idEjemplo: EjemploId,
                                id:-1
                            },
                            success: function (result) {                               
                                //$("#Div_ejemplo").empty();
                                $("#div_ejemplo").append(result);                                
                            },
                            error: function () {
                                alert("error");
                            }
                        });


                        $.ajax({
                            url: serverUrl + '/EjemploDetalles/LstEjemploDetalleArbol',
                            type: 'GET',
                            data: {
                                EjemploId: EjemploId
                            },
                            success: function (result) {
                                $("#div_EjemDet_" + EjemploId).empty();
                                $("#div_EjemDet_" + EjemploId).append(result);
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