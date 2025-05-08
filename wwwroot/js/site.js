const alertPlaceholder = document.getElementById('PlaceHolderAlert') //Espacio donde dibuja el alert
const alertTrigger = document.getElementById('BtnGuardar') //Boton del form
const formulario = document.getElementById('NuevoPerfilForm'); //Formulario

//Dibuja el alert cuando invodada
function alert(message, type) {
    var Contenido = document.createElement('div')
    Contenido.innerHTML = '<div class="alert alert-'
        + type +
        ' alert-dismissible" role="alert">'
        + message
        + '<button type="submit" class="btn-close" data-bs-dismiss="alert" aria-label="Close" onclick="enviarFormulario()" > </button></div>'

    alertPlaceholder.append(Contenido)
}
//Hace submit del form, se invoca desde el boton de cerrar del alert
function enviarFormulario() {
    formulario.submit();
}
//Al boton del form, al hacer clic, invoca a la funcion alert
if (alertTrigger) {
    alertTrigger.addEventListener('click', function () {
        alert('Perfil creado exitosamente', 'success')
    })
}