using MotorsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using MySqlX.XDevAPI;
using System.Windows.Forms;

namespace MotorsForm.Services
{
    public class CarroService
    {
        HttpClient client = new HttpClient();
        public async Task<Respuesta> enviarEspecs(CarroFlotaRequest carro)
        {

            HttpClient client = new HttpClient();
            var datos = JsonConvert.SerializeObject(carro);
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/flotaCarro/save", data);
            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);


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


        public async void eliminarEnAlquiler(string placa)
        {
            var respuesta = await client.DeleteAsync($"https://localhost:7129/MotorsApi/ventaFlota/Delete/{placa}");

            if (!respuesta.IsSuccessStatusCode)
            {
                var mensajeError = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {mensajeError}");
            }
        }

        public async void nuevaVenta(string placa)
        {
            var venta = new Ventas()
            {
                id_vehiculo = placa
            };
            var datos = JsonConvert.SerializeObject(venta);
            var content = new StringContent(datos, Encoding.UTF8, "application/json");

            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/ventaFlota/venta", content);
        }

        public async Task<Respuesta> enviarNuevaSubasta(SubastaRequest alquilersin)
        {
            try
            {
                var datos = JsonConvert.SerializeObject(alquilersin);
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

        public async Task<Respuesta> nuevaTarifa(TarifasAlquilerRequest tarifiña)
        {
            HttpClient client = new HttpClient();

            var datos = JsonConvert.SerializeObject(tarifiña);
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/Alquiler/nueva/Tarifa", data);

            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
        }
    }
}
