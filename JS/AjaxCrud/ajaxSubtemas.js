    $(document).ready(function () {
        $("#frm-alumno").submit(function () {
            var serverUrl = window.location.origin;
            var temaId = $("#TemaId").val();
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
                                url: serverUrl + '/Subtemas/recargarArbolPrincipal',
                                type: 'GET',
                                data: {
                                    //Passing Input parameter
                                    temaId: temaId
                                },
                                success: function (result) {
                                    $("#div_arbol").empty();
                                    $("#div_arbol").append(result);
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