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
        }

        public async Task<Respuesta> actualizarEstado(AlquilerRecue recue, string estado)
        {
            try
            {
                var datos = JsonConvert.SerializeObject(recue);
                var content = new StringContent(datos, Encoding.UTF8, "application/json");

                string text = $"https://localhost:7129/MotorsApi/Alquiler/alquiler/{estado}";

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

        //public async Task<List<FlotaCarro>> dameLosCarritos()
        //{
        //    var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/Alquiler/carros/alquiler");

        //    return JsonConvert.DeserializeObject<List<FlotaCarro>>(respuesta.Content.ReadAsStringAsync().Result);
        //}

        public async Task<List<TarifasAlquilerRequest>> obtenerTarifasAll()
        {
            HttpClient client = new HttpClient();
            var carnalito = await client.GetAsync("https://localhost:7129/MotorsApi/Alquiler/tarifas");

            return JsonConvert.DeserializeObject<List<TarifasAlquilerRequest>>(carnalito.Content.ReadAsStringAsync().Result);
        }

        public async Task<Respuesta> enviarNuevaTarifa(double id, TarifasAlquilerRequest carro)
        {
            HttpClient client = new HttpClient();

            var datos = JsonConvert.SerializeObject(carro);
            var content = new StringContent(datos, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), ($"https://localhost:7129/MotorsApi/Alquiler/editar/Tarifa/%7Bid%7D"))
            {
                Content = content
            };

            var respuestaHttp = await client.SendAsync(request);

            if (!respuestaHttp.IsSuccessStatusCode)
            {
                return new Respuesta
                {
                    Titulo = "Error de comunicación",
                    Mensaje = $"Error: {respuestaHttp.StatusCode} - {respuestaHttp.ReasonPhrase}",
                    Code = (int)respuestaHttp.StatusCode
                };
            }

            var respuestaJson = await respuestaHttp.Content.ReadAsStringAsync();
            var respuesta = JsonConvert.DeserializeObject<Respuesta>(respuestaJson);

            return respuesta;

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

        public async void EliminarDeVentas(string placa)
        {
            var respuesta = await client.DeleteAsync($"https://localhost:7129/MotorsApi/ventaFlota/Delete/{placa}");

            if (!respuesta.IsSuccessStatusCode)
            {
                var mensajeError = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {mensajeError}");
            }
        }

        public async Task<List<FlotaCarro>> RecibirCarros()
        {
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/Alquiler/carros");

            return JsonConvert.DeserializeObject<List<FlotaCarro>>(respuesta.Content.ReadAsStringAsync().Result);
        }

        public async Task<List<FlotaCarro>> RecibirCarrosAlquiler()
        {
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/Alquiler/carros/alquiler");

            return JsonConvert.DeserializeObject<List<FlotaCarro>>(respuesta.Content.ReadAsStringAsync().Result);
        }
    }
}
