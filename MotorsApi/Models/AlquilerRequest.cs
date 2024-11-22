using System.ComponentModel.DataAnnotations;

namespace MotorsApi.Models
{
    public class AlquilerRequest
    {
        [Required]
        public string placa { get; set; } = string.Empty; // Obligatorio

        [Required]
        public int idUsuario { get; set; } // Obligatorio

        [Required]
        public int tipoTarifa { get; set; } // Obligatorio

        [Required]
        public DateTime fechaRetiro { get; set; } // Obligatorio

        [Required]
        public DateTime fechaEntrega { get; set; } // Obligatorio

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser mayor o igual a 0.")]
        public double precioTotal { get; set; } // Obligatorio y debe ser un número válido

        [Required]
        public int idSeguro { get; set; } // Obligatorio
    }
}
