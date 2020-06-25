function toast_success(msj) {
    toastr.success(msj, 'Exito', {
        'progressBar': true,
        "closeButton": true,
        "timeOut": "2000",
        "positionClass": "toast-bottom-right",
    })
}