//Completar código aquí para gestionar el evento click del botón Filtra
//Puede utilizar la API Fetch para recuperar los datos de la WEBAPI
function mostrarEnvios(envios) {
    const contenedor = document.getElementById('listaEnvios');
    contenedor.innerHTML = ''; // Limpiamos cualquier contenido previo

    // Si no hay envíos, mostramos un mensaje
    if (envios.length === 0) {
        contenedor.innerHTML = '<li>No se encontraron envíos.</li>';
        return;
    }

    // Recorremos el array de envíos y los mostramos
    envios.forEach(envio => {
        const item = document.createElement('li');
        item.textContent = `Envío #${envio.id}: ${envio.descripcion}`;
        contenedor.appendChild(item);
    });
}

// Función para manejar el evento de clic del botón Filtrar
document.getElementById('btnFiltrar').addEventListener('click', function() {
    // Obtener el valor del campo de filtro
    const filtro = document.getElementById('filtro').value.trim();

    // Si no se ingresó texto, mostramos un mensaje y detenemos la búsqueda
    if (filtro === '') {
        alert('Por favor ingresa un término de filtro.');
        return;
    }

    // URL de la API con un parámetro de filtro
    const apiUrl = `http://localhost:5115/swagger/index.html`;

    // Realizamos la petición GET a la API
    fetch(apiUrl)
        .then(response => response.json())  // Convertimos la respuesta a formato JSON
        .then(data => {
            console.log(data); // Ver los datos en la consola
            mostrarEnvios(data); // Mostrar los envíos filtrados
        })
        .catch(error => console.error('Error al obtener los envíos:', error));
});