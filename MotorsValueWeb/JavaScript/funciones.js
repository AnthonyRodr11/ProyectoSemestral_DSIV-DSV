
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

function cargarHTML(idElemento, archivo) {
    fetch(archivo)
        .then((response) => {
            if (!response.ok) {
                throw new Error(`Error al cargar ${archivo}: ${response.statusText}`);
            }
            return response.text();
        })
        .then((data) => {
            // Insertar el contenido HTML en el elemento especificado
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
        })
        .catch((error) => console.error(`Error cargando el archivo:`, error));
}

function cargarNavbar(idElemento, archivo) {
    fetch(archivo)
        .then((response) => {
            if (!response.ok) {
                throw new Error(`Error al cargar ${archivo}: ${response.statusText}`);
            }
            return response.text();
        })
        .then((data) => {
            // Insertar el contenido HTML en el elemento especificado
            const elemento = document.getElementById(idElemento);
            elemento.innerHTML = data;

            // Buscar y ejecutar los scripts en el contenido cargado
            const scripts = elemento.querySelectorAll('script');
            scripts.forEach((script) => {
                const nuevoScript = document.createElement('script');
                if (script.src) {
                    nuevoScript.src = script.src;
                    nuevoScript.async = true;
                } else {
                    nuevoScript.textContent = script.textContent;
                }
                document.body.appendChild(nuevoScript);
                script.remove();
            });

            // Re-asignar eventos dinámicos aquí
            inicializarMenuAcordeon();
        })
        .catch((error) => console.error(`Error cargando el archivo:`, error));
}

function inicializarMenuAcordeon() {
    const toggleButton = document.querySelector(".menu-toggle");
    const menu = document.querySelector(".menu");

    if (toggleButton && menu) {
        toggleButton.addEventListener("click", () => {
            menu.style.display = menu.style.display === "flex" ? "none" : "flex";
        });
    }
}

