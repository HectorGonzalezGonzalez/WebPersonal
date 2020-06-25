function alertSw(icon, title, text) {
    //Swal.fire('Any fool can use a computer');
    Swal.fire({
        icon: icon,
        title: title,
        text: text,
        confirmButtonText:'Aceptar'
    })
}

//function DelConfirm() {
//    var salir = false;
//   await Swal.fire({
//        title: '¿Esta seguro de Borrar?',
//        text: "Este contenido no se podra recuperar!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Si Borrar!',
//        closeOnconfirm:true
//    }).then((result) => {
//        if (result.value) {            
//            salir = result.value;            
//        }
//    })
//    alert(salir);
//    return salir;
//}

