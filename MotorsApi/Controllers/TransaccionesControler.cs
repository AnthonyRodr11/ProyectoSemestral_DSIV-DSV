using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Read;
namespace MotorsApi.Controllers

{

    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class TransaccionesControler : ControllerBase
    {

        [HttpGet]
        [Route("pefil/{id}")]
        public IActionResult obtenerTransaccionAlquiler(int id_usuario)
        {
            HistorialTransacciones hitorialin = new HistorialTransacciones();
            var parqueplacentero = hitorialin.obtenerMiAlquiler(id_usuario);


            if (parqueplacentero == null)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 202
                });
    
               
            }
            

            return Ok(hitorialin);
        }





    }
}
