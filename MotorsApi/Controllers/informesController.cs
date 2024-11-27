using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace MotorsApi.Controllers

{


    [Route("MotorsApi/[controller]")]
    [ApiController]

    public class informesController : ControllerBase
    {

        
            [HttpGet]
            [Route("infoFlota")]
            public IActionResult obtenerInfoFlota()
            {
                var db = new Informes(); // Inicializar clase donde tienes los métodos
                var data = db.infoFlota();
                return Ok(data);
            }

            // Método para obtener la información de ventas
            [HttpGet]
            [Route("infoVentas")]
            public async Task<IActionResult> obtenerInfoVentas()
            {
                var db = new Informes();
                var data = await db.infoVentas();
                return Ok(data);
            }

            // Método para obtener la información de alquileres
            [HttpGet]
            [Route("infoAlquiler")]
            public IActionResult obtenerInfoAlquiler()
            {
                var db = new Informes();
                var data = db.infoAlquiler();
                return Ok(data);
            }

            // Método para obtener la información de subastas
            [HttpGet]
            [Route("infoSubastas")]
            public IActionResult obtenerInfoSubastas()
            {
                var db = new Informes();
                var data = db.infoSubastas();
                return Ok(data);
            }

            // Método para obtener la información de solicitudes
            [HttpGet]
            [Route("infoSolicitudes")]
            public IActionResult obtenerInfoSolicitudes()
            {
                var db = new Informes();
                var data = db.infoSolicitudes();
                return Ok(data);
            }




    }





}

