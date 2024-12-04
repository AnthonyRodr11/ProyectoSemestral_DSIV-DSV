
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MotorsForm.Models;
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
                string url = $"https://localhost:7129/MotorsApi/Usuario/form/login/{Uri.EscapeDataString(mail)}/{Uri.EscapeDataString(password)}";

                // Realizar la solicitud GET
                var respuesta = await client.GetAsync(url);

                // Verificar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    return 0;
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

        public async Task<int> RegistrarUsuario(RegistroRequest user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Serializar los datos
                    var datos = JsonConvert.SerializeObject(user);
                    var data = new StringContent(datos, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/Usuario/user/new", data);

                    // Verificar si la solicitud fue exitosa
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return 1;
                        // Envío exitoso
                    }
                    else
                    {
                        return 0; // Error en el envío
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y devolver 0 para indicar error
                Console.WriteLine($"Error al enviar los datos: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> VerificarCorreo(string mail)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construir la URL con parámetros
                string url = $"https://localhost:7129/MotorsApi/Usuario/user/email/{Uri.EscapeDataString(mail)}";

                // Realizar la solicitud GET
                    var respuesta = await client.GetAsync(url);

                // Verificar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    return 0;
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

        public async Task<List<User>> ObternerUserInfo(int id)
        {
            HttpClient client = new HttpClient();

            var respuesta = await client.GetAsync($"https://localhost:7129/MotorsApi/Usuario/userInfo/{(id)}");

            return JsonConvert.DeserializeObject<List<User>>(respuesta.Content.ReadAsStringAsync().Result);
        }

        public async Task<int> EditarUser(string mail, UpdateRequest update)
        {
            using (HttpClient client = new HttpClient())
            {
                var datos = JsonConvert.SerializeObject(update);
                var data = new StringContent(datos, Encoding.UTF8, "application/json");

                // Construir la URL con parámetros
                var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"https://localhost:7129/MotorsApi/Usuario/user/update/{Uri.EscapeDataString(mail)}"
                );

                // Establecer el contenido del cuerpo de la solicitud
                request.Content = data;

                // Realizar la solicitud
                var respuesta = await client.SendAsync(request);

                // Verificar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<int> EliminarUsuario(string mail)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                  
                    // Enviar la solicitud DELETE
                    var respuesta = await client.DeleteAsync($"https://localhost:7129/MotorsApi/Usuario/user/delete/{Uri.EscapeDataString(mail)}");

                    // Verificar si la solicitud fue exitosa
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return 1;   
                        // Envío exitoso
                    }
                    else
                    {
                        return 0; // Error en el envío
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y devolver 0 para indicar error
                Console.WriteLine($"Error al enviar los datos: {ex.Message}");
                return 0;
            }
        }


    }
}
