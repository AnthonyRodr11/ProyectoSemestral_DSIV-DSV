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

namespace MotorsForm.Services
{
    public class CarroService
    {
        public async Task<Respuesta> enviarEspecs(CarroFlotaRequest carro)
        {

            HttpClient client = new HttpClient();
            var datos = JsonConvert.SerializeObject(carro);
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/flotaCarro/save", data);
            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
        }

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
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), ($"https://localhost:7129/MotorsApi/Alquiler/editar/Tarifa/{id}"))
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

    }
}
