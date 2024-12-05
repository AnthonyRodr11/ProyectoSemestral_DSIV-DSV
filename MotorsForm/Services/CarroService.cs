using MotorsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MotorsForm.Services
{
    public class CarroService
    {
        public async Task<Respuesta> obtenerEspec(CarroFlotaRequest carro)
        {

            HttpClient client = new HttpClient();
            var datos = JsonConvert.SerializeObject(carro);
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var respuesta = await client.PostAsync("https://localhost:7129/MotorsApi/flotaCarro/save", data );
            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
        }
    }
}
