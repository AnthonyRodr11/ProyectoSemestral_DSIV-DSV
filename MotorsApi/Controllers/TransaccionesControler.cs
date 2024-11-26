using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Read;
namespace MotorsApi.Controllers

{

    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class TransaccionesControler : ControllerBase
    {

        //Controller para alquiler lista

        [HttpGet]
        [Route("perfil/Alquiler/{id}")]
        public IActionResult obtenerTransaccionAlquiler(int id_usuario)
        {
            HistorialTransacciones historial = new HistorialTransacciones();
            var misAlquileres = historial.obtenerMiAlquiler(id_usuario);


            if (misAlquileres == null)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 202
                });


            }
            return Ok(misAlquileres);
        }

        //Controller para Venta lista

        [HttpGet]
        [Route("perfil/Venta/{id}")]
        public IActionResult obtenerTransaccionVenta(int id_usuario)
        {
            HistorialTransacciones hitorialin = new HistorialTransacciones();
            var misVentas = hitorialin.obtenerMisCompras(id_usuario);


            if (misVentas == null)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 202
                });


            }


            return Ok(misVentas);
        }

        //Controller para Subasta lista

        [HttpGet]
        [Route("perfil/subasta/{id}")]
        public IActionResult obtenerTransaccionSubasta(int id_usuario)
        {
            HistorialTransacciones historial = new HistorialTransacciones();
            var misSubastas = historial.obtenerMisSubastas(id_usuario);


            if (misSubastas == null)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 202
                });


            }

            return Ok(misSubastas);
        }
    }
}
