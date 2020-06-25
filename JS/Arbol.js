function acordeon(subtemaId) {    
    //e.preventDefault();/*Se utiliza para que no ponga el gato en la url y no se mueva la pagina por si tiene scrol, sube la pagina*/
    var contenido = $("#link_acordion_" + subtemaId).nextAll(".accordion-content");
    // alert(contenido);

    if (contenido.css("display") == "none") { //open		
        contenido.slideDown(250);
        $("#link_acordion_" + subtemaId).addClass("open");
        mostrarDatosSubtemaDetalle(subtemaId);        
    }
    else { //close		
        contenido.slideUp(250);
        $("#link_acordion_" + subtemaId).removeClass("open");
    }
}
   




/*AJAX DE FORMA MANUAL */

function manejarErrorAjax(err) {
    alert(err.responseText);
}
/*Acciones Ajax CRUD*/
function LimpiarDiv_ejemplo() {
    $("#div_ejemplo").empty();
}

