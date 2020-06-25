$("#btnNuevo").click(function (evt) {
    $("#modal-content").load("/Temas/Create");
});
$(".btnEditar").click(function (evt) {
    $("#modal-content").load("/Temas/Edit/" + $(this).data("id"));
});
$(".btnEliminar").click(function (evt) {
    $("#modal-content").load("/Temas/Delete/" + $(this).data("id"));
});
