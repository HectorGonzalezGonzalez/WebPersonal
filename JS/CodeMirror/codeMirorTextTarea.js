myTextarea = document.getElementsByName("Codigo");
console.log($(myTextarea).length);
var cm = new Array();
for (i = 0; i < myTextarea.length; i++) {

    cm[i] = CodeMirror.fromTextArea($(myTextarea[i])[0], {
        mode: "text/html",
        lineNumbers: true,
        lineWrapping: true,
        indentUnit: 4,
        height: 400
    });
};