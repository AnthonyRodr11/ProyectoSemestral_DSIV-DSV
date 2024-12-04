using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using MySqlX.XDevAPI;


namespace MotorsForm.Services
{
    public class InformesService
    {
        //Metodo para obtener el arreglo con la data a escribir
        public async Task<String[]> obtenerFlotaInfo()
        {
            HttpClient cliente = new HttpClient();

            try
            {
                // Cambia esta URL por la de tu API
                var respuesta = await cliente.GetAsync("https://localhost:7129/MotorsApi/informes/infoFlota");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializa el contenido a un arreglo de strings
                    return JsonSerializer.Deserialize<string[]>(contenido);
                }
                else
                {
                    throw new Exception($"Error al obtener información de la flota: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        //Metodo para obtener el arreglo con informacion de Venta de Autos
        public async Task<String[]> obtenerVentaInfo()
        {
            HttpClient cliente = new HttpClient();

            try
            {
                // Cambia esta URL por la de tu API
                var respuesta = await cliente.GetAsync("https://localhost:7129/MotorsApi/informes/infoVentas");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializa el contenido a un arreglo de strings
                    return JsonSerializer.Deserialize<string[]>(contenido);
                }
                else
                {
                    throw new Exception($"Error al obtener información de Venta: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        //obtener el arreglo con la informacion de alquiler
        public async Task<String[]> obtenerAlquilerInfo()
        {
            HttpClient cliente = new HttpClient();

            try
            {
                // Cambia esta URL por la de tu API
                var respuesta = await cliente.GetAsync("https://localhost:7129/MotorsApi/informes/infoAlquiler");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializa el contenido a un arreglo de strings
                    return JsonSerializer.Deserialize<string[]>(contenido);
                }
                else
                {
                    throw new Exception($"Error al obtener información de Alquiler de Autos: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        //obtener el arreglo con la informacion de Subasta
        public async Task<String[]> obtenerSubastaInfo()
        {
            HttpClient cliente = new HttpClient();

            try
            {
                // Cambia esta URL por la de tu API
                var respuesta = await cliente.GetAsync("https://localhost:7129/MotorsApi/informes/infoSubastas");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializa el contenido a un arreglo de strings
                    return JsonSerializer.Deserialize<string[]>(contenido);
                }
                else
                {
                    throw new Exception($"Error al obtener información de Autos en Subasta: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        //obtener el arreglo con la informacion de Solicitudes
        public async Task<String[]> obtenerSolicitudesInfo()
        {
            HttpClient cliente = new HttpClient();

            try
            {
                // Cambia esta URL por la de tu API
                var respuesta = await cliente.GetAsync("https://localhost:7129/MotorsApi/informes/infoSolicitudes");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializa el contenido a un arreglo de strings
                    return JsonSerializer.Deserialize<string[]>(contenido);
                }
                else
                {
                    throw new Exception($"Error al obtener información de Solicitudes: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al realizar la solicitud: {ex.Message}");
            }
        }


    }
}
