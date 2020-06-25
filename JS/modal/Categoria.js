$("#btnNuevo").click(function (evt) {
    $("#modal-content").load("/Categorias/Create");
});
$(".btnEditar").click(function (evt) {
    $("#modal-content").load("/Categorias/Edit/" + $(this).data("id"));
});
$(".btnEliminar").click(function (evt) {
    $("#modal-content").load("/Categorias/Delete/" + $(this).data("id"));
});
