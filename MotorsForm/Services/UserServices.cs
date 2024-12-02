
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MotorsForm.Services
{
    internal class UserServices
    {
        public async Task<int> ObtenerAcceso(string mail, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construir la URL con parámetros
                string url = $"https://localhost:7219/MotorsApi/Usuario/form/login?mail={Uri.EscapeDataString(mail)}&password={Uri.EscapeDataString(password)}";

                // Realizar la solicitud GET
                var respuesta = await client.GetAsync(url);

                // Verificar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error en la solicitud: {respuesta.StatusCode}");
                }

                // Leer el contenido de la respuesta como texto
                string contenido = await respuesta.Content.ReadAsStringAsync();

                // Deserializar y retornar el resultado como entero
                if (int.TryParse(contenido, out int resultado))
                {
                    return resultado;
                }

                throw new JsonException("El contenido de la respuesta no es un entero válido.");
            }
        }



    }
}
