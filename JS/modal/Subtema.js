$(".btnNuevo").click(function (evt) {
    $("#modal-content").load("/Subtemas/Create?idTema=" + $(this).data("id"));
});
$(".btnEditar").click(function (evt) {
    $("#modal-content").load("/Subtemas/Edit/" + $(this).data("id"));
});
$(".btnEliminar").click(function (evt) {
    $("#modal-content").load("/Subtemas/Delete/" + $(this).data("id"));
});
