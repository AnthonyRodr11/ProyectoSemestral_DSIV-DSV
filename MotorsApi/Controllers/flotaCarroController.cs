using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.Models;
namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class flotaCarroController : ControllerBase
    {
        [HttpPost]
        [Route("save")]
        public object registrarAuto(Flota_Carro autos) 
        {
            
            Flota_Auto regAuto = new Flota_Auto();

            var guardado = regAuto.registraAutoflota(autos);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al guardar",
                    Mensaje = "Los datos se han guardado correctamente",
                    Code = 200
                };
            return new
            {
                titulo = "Error al guardar",
                Mensaje = "Los datos explotaron",
                Code = 400
            };
        }
    }


}
