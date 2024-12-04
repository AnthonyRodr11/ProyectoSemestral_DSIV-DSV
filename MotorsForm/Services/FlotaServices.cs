using MotorsForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Services
{
    internal class FlotaServices
    {
        public async Task<List<FlotaRequest>> ObternerTodaLaFlota()
        {
            HttpClient client = new HttpClient();
            var respuesta = await client.GetAsync("https://localhost:7129/MotorsApi/flotaCarro/flota");

            return JsonConvert.DeserializeObject<List<FlotaRequest>>(respuesta.Content.ReadAsStringAsync().Result);
        }
    }
}
