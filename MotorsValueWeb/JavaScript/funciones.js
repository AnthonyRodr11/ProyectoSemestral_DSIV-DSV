
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
