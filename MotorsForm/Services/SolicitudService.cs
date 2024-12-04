using MotorsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotorsForm.Services
{
    public class SolicitudService
    {
        //Metodo para mostrar todas las solicitudes 
        public async Task<List<Solicitud>> obtenerSolicitudes()
        {
            HttpClient client = new HttpClient();
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/solicitudes/listaSolicitantes");

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Solicitud>>(contenido);
            }
            else
            {
                throw new Exception($"Error al obtener solicitudes: {respuesta.StatusCode}");
            }
        }

        //Metodo para obtener el nombre y apellido
        public async Task<string> obtenerNombre(int id_solicitud)
        {
            HttpClient client = new HttpClient();

            try
            {
                var respuesta = await client.GetAsync($"https://localhost:7129/MotorsApi/solicitudes/nombreSolicitante/{id_solicitud}");

                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Error al obtener el nombre: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud de nombre: {ex.Message}");
            }
        }

        //Metodo para obtener el Monto
        public async Task<double> obtenerMonto(int id_solicitud)
        {

            HttpClient client = new HttpClient();

            try
            {
                var respuesta = await client.GetAsync($"https://localhost:7129/MotorsApi/solicitudes/monto/{id_solicitud}");

                if (respuesta.IsSuccessStatusCode)
                {
                    var monto = await respuesta.Content.ReadAsStringAsync();

                    // Convertir el monto recibido en string a double
                    if (double.TryParse(monto, out var montoDouble))
                    {
                        return montoDouble;
                    }
                    else
                    {
                        throw new Exception("El monto recibido no es un número válido.");
                    }
                }
                else
                {
                    throw new Exception($"Error al obtener el monto: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud de monto: {ex.Message}");
            }
        }

        //metodor para obtener la descripcion de la solicitud
        public async Task<string> obtenerDescripcion(int id_solicitud)
        {
            HttpClient client = new HttpClient();

            try
            {
                var respuesta = await client.GetAsync($"https://localhost:7129/MotorsApi/solicitudes/descripcion/{id_solicitud}");

                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Error al obtener la descripción: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud de descripción: {ex.Message}");
            }
        }

        //Metodo para mandar aceptar la solicitud
        public async Task<int> aceptar(int id_solicitud)
        {
            HttpClient client = new HttpClient();

            try
            {
                // Crear el mensaje HTTP con el método PATCH
                var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                    $"https://localhost:7129/MotorsApi/solicitudes/aceptarSolicitud/{id_solicitud}");

                // Enviar la solicitud
                var response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    return 1; // Indica éxito
                }
                else
                {
                    throw new Exception($"Error al aceptar solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        //metodo para mandar a rechazar solicitud 
        public async Task<int> rechazar(int id_solicitud)
        {
            HttpClient client = new HttpClient();

            try
            {
                // Crear el mensaje HTTP con el método PATCH
                var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                    $"https://localhost:7129/MotorsApi/solicitudes/rechazarSolicitud/{id_solicitud}");

                // Enviar la solicitud
                var response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    return 1; // Indica éxito
                }
                else
                {
                    throw new Exception($"Error al rechazar solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }
    }
}
