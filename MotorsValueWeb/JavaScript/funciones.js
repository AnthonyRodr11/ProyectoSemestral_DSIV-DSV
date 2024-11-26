
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
            const elemento = document.getElementById(idElemento);
            elemento.innerHTML = data;

            // Aquí notificamos que la carga ha finalizado para realizar inicializaciones
            if (idElemento === "navbar") {
                inicializarNavbar();
            }
        })
        .catch((error) => console.error(`Error cargando el archivo:`, error));
}

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
        // Usuario no registrado: botones a "Registrarse"
        actionButton.href = "register.html";
        actionButton.innerText = "Registrarse";

        dropdownActionButton.href = "register.html";
        dropdownActionButton.innerText = "Registrarse";
    }
}
