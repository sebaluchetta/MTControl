
document.getElementById('BtnExpPdf').addEventListener('click', () => {
    const element = document.getElementById('ProfileTable');
    const opt = {
        margin:       0.5,
    filename:     'Perfiles.pdf',
    image:        {type: 'jpeg', quality: 0.98 },
    html2canvas:  {scale: 2 },
    jsPDF:        {unit: 'in', format: 'a4', orientation: 'landscape' }
    };
    // Genera y descarga
    html2pdf().set(opt).from(element).save();
});

function Limpiar() {
    document.getElementById('InputBuscar').value = '';
}

document.getElementById('BtnLimpiar').addEventListener('click', () => {
    Limpiar();
});

