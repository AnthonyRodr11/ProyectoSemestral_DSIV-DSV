
class Funciones {

    // Método para solo permitir numeros y que le ponga la coma adecuadament
    formatearMonto(input) {
        input.oninput = function () {
            var removeChar = this.value.replace(/[^0-9\.]/g, ''); // Eliminar caracteres no numéricos excepto el punto
            var removeDot = removeChar.replace(/\./g, ''); // Eliminar puntos innecesarios
            this.value = removeDot;

            var formatedNumber = this.value.replace(/\B(?=(\d{3})+(?!\d))/g, ","); // Formato de miles
            this.value = formatedNumber;
        };
    }
}

//Metodo para cargar los script propios de navbar en cada HTML
function cargarHTML(idElemento, archivo) {
    fetch(archivo)
        .then((response) => {
            if (!response.ok) {
                throw new Error(`Error al cargar ${archivo}: ${response.statusText}`);
            }
            return response.text();
        })
        .then((data) => {
            const elemento = document.getElementById(idElemento);
            elemento.innerHTML = data;

            // Buscar y ejecutar los scripts en el contenido cargado
            const scripts = elemento.querySelectorAll('script');
            scripts.forEach((script) => {
                const nuevoScript = document.createElement('script');
                if (script.src) {
                    // Si el script tiene un src, se vuelve a cargar
                    nuevoScript.src = script.src;
                    nuevoScript.async = true; // Asegura ejecución independiente
                } else {
                    // Si el script es inline, copia su contenido
                    nuevoScript.textContent = script.textContent;
                }
                document.body.appendChild(nuevoScript); // Añadir el script al DOM
                script.remove(); // Opcional: eliminar el script original
            });

            if (idElemento === "navbar") {
                inicializarNavbar();
            }
        })
        .catch((error) => console.error(`Error cargando el archivo:`, error));
}

// Inicializar el icono de perfil y sus funciones para cada pagina
function inicializarNavbar() {
    // Selecciona los botones del navbar
    const actionButton = document.getElementById("actionButton");
    const dropdownActionButton = document.getElementById("dropdownActionButton");

    // Recupera el estado del usuario del almacenamiento local
    const userId = localStorage.getItem("userId");

    if (userId) {
        // Usuario está registrado: cambia los botones a "Perfil"
        actionButton.href = "perfil.html";
        actionButton.innerHTML = `<i class="fa-solid fa-user"></i> Perfil`;

        dropdownActionButton.href = "perfil.html";
        dropdownActionButton.innerHTML = `<i class="fa-solid fa-user"></i> Perfil`;
    } else {
        // Usuario no registrado: botones a "Iniciar Sesion"
        actionButton.href = "login.html";
        actionButton.innerText = "Iniciar sesion";

        dropdownActionButton.href = "login.html";
        dropdownActionButton.innerText = "Iniciar sesion";
    }
}
