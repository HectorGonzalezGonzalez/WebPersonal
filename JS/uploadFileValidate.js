function change_fileValidation() {            
    var resVal = validarImagenFormato();
        if (resVal == true) {
            var fileInput = document.getElementById('ImgFile');
            //Image preview  
            document.getElementById("MenssageError").innerHTML = "";
            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById('imagePreview').innerHTML = '<img src="' + e.target.result + '"/>';
                };
                reader.readAsDataURL(fileInput.files[0]);
            }
        }               
}
function form_validarImagenFormat(tkAction) {    
    var salir = true;
    switch (tkAction) {
        case "add":
            salir = validarImagenFormato();
            break;
        case "upd":
            //var img_r = dimg_rocument.getElementById('img').value; 
            var fileInput = document.getElementById('ImgFile').value;            
            if (fileInput != "" && fileInput!=null) {
                salir = validarImagenFormato();
            }
            break;
    }

    return salir;
}

function validarImagenFormato() {    
    var salir = true;    
        var fileInput = document.getElementById('ImgFile');
        var filePath = fileInput.value;
        var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
        if (!allowedExtensions.exec(filePath)) {
            fileInput.value = '';
            document.getElementById("MenssageError").innerHTML = "Selecciona una imagen con la extensión: .jpeg/.jpg/.png/.gif";
            salir = false;
        }    
    return salir;
}