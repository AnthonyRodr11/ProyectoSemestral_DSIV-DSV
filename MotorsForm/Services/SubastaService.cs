using MotorsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySqlX.XDevAPI;
using System.Windows.Forms;

namespace MotorsForm.Services
{
    public class SubastaService
    {
        HttpClient client = new HttpClient();
        public async Task<Respuesta> EnviarNuevaSubasta(SubastaRequest subastita)
        {
            try
            {
                var datos = JsonConvert.SerializeObject(subastita);
                var content = new StringContent(datos, Encoding.UTF8, "application/json");

                var respuestaHttp = await client.PostAsync("https://localhost:7129/MotorsApi/flotaCarro/create/subasta", content);

                if (!respuestaHttp.IsSuccessStatusCode)
                {
                    return new Respuesta
                    {
                        titulo = "Error de comunicación",
                        mensaje = $"Error: {respuestaHttp.StatusCode} - {respuestaHttp.ReasonPhrase}",
                        code = (int)respuestaHttp.StatusCode
                    };
                }

                var respuestaJson = await respuestaHttp.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(respuestaJson);

                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    titulo = "Error inesperado",
                    mensaje = ex.Message,
                    code = 500
                };
            }
        }

        public async Task<Respuesta> ActualizarEstado(SubastaRequest subastita)
        {
            try
            {
                var datos = JsonConvert.SerializeObject(subastita);
                var content = new StringContent(datos, Encoding.UTF8, "application/json");


                // Crear solicitud personalizada para el Patch
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://localhost:7129/MotorsApi/Subasta/subasta")
                {
                    Content = content
                };

                var respuestaHttp = await client.SendAsync(request);

                if (!respuestaHttp.IsSuccessStatusCode)
                {
                    return new Respuesta
                    {
                        titulo = "Error de comunicación",
                        mensaje = $"Error: {respuestaHttp.StatusCode} - {respuestaHttp.ReasonPhrase}",
                        code = (int)respuestaHttp.StatusCode
                    };
                }

                var respuestaJson = await respuestaHttp.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(respuestaJson);

                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    titulo = "Error inesperado",
                    mensaje = ex.Message,
                    code = 500
                };
            }
        }

        public async Task<Respuesta> ActualizarEstado(SubastaRequest subastita, string estado)
        {
            try
            {
                var datos = JsonConvert.SerializeObject(subastita);
                var content = new StringContent(datos, Encoding.UTF8, "application/json");

                string text = $"https://localhost:7129/MotorsApi/Subasta/subasta/{estado}";

                // Crear solicitud personalizada para el Patch
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), text)
                {
                    Content = content
                };

                var respuestaHttp = await client.SendAsync(request);

                if (!respuestaHttp.IsSuccessStatusCode)
                {
                    return new Respuesta
                    {
                        titulo = "Error de comunicación",
                        mensaje = $"Error: {respuestaHttp.StatusCode} - {respuestaHttp.ReasonPhrase}",
                        code = (int)respuestaHttp.StatusCode
                    };
                }

                var respuestaJson = await respuestaHttp.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(respuestaJson);

                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    titulo = "Error inesperado",
                    mensaje = ex.Message,
                    code = 500
                };
            }
        }

        public async Task<List<FlotaCarro>> RecibirCarros()
        {
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/Subasta/carros");

            return JsonConvert.DeserializeObject<List<FlotaCarro>>(respuesta.Content.ReadAsStringAsync().Result);
        }

        public async Task<List<FlotaCarro>> RecibirCarrosSubasta()
        {
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/Subasta/carros/subasta");

            return JsonConvert.DeserializeObject<List<FlotaCarro>>(respuesta.Content.ReadAsStringAsync().Result);
        }


        public async void EliminarDeSubasta(string placa)
        {
            var respuesta = await client.DeleteAsync($"https://localhost:7129/MotorsApi/Subasta/carros/subasta/{placa}");

            if (!respuesta.IsSuccessStatusCode)
            {
                var mensajeError = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {mensajeError}");
            }
        }

        public async void NuevaVenta(string placa)
        {
            var venta = new Ventas()
            {
                id_vehiculo = placa
            };
            var datos = JsonConvert.SerializeObject(venta);
            var content = new StringContent(datos, Encoding.UTF8, "application/json");

            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/ventaFlota/venta", content);
        }


        public async void EliminarDeVentas(string placa)
        {
            var respuesta = await client.DeleteAsync($"https://localhost:7129/MotorsApi/ventaFlota/Delete/{placa}");

            if (!respuesta.IsSuccessStatusCode)
            {
                var mensajeError = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {mensajeError}");
            }
        }

    }
}
