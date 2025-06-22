
//Valido para ProfileCR y ProfileU 
//Mantiene el label del toggle actualizado segun el valor del toggle
if (document.getElementById('ToggleActivo') && document.getElementById('ToggleLabel')) {
    function ActualizarToggleLabel() {
        let ToggleLabel = "";
        let ToggleValue = false;
        ToggleValue = document.getElementById('ToggleActivo').checked;
        document.getElementById('ToggleLabel').innerText= ToggleValue ? 'Activo' : 'Inactivo';
    }
    document.addEventListener('DOMContentLoaded', ActualizarToggleLabel);
    document.getElementById('ToggleActivo')
        .addEventListener('change', ActualizarToggleLabel);

}
//Valido para Profile
//Limpia el input del buscador al hacer clic en el boton de limpiar
if (document.getElementById('InputBuscar') && document.getElementById('BtnLimpiar')) {
    function Limpiar() {
        document.getElementById('InputBuscar').value = '';
    }
    document.getElementById('BtnLimpiar')
        .addEventListener('click', () => {
            Limpiar();
        });
}


