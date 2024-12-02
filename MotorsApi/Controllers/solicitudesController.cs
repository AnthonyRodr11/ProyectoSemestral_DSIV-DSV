using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.Models;
namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class solicitudesController : ControllerBase
    {

        [HttpPost]
        [Route("save")]
        public IActionResult registrarSolicitud([FromBody] solicitudRequest peticion)
        {
            try
            {
                // Validar que el monto sea válido
                if (peticion.monto <= 0)
                {
                    return BadRequest(new
                    {
                        titulo = "Error de validación",
                        mensaje = "El monto debe ser mayor que 0.",
                        codigo = 400
                    });
                }

                // Crear instancia de la clase que interactúa con la base de datos
                Solicitudes solicita = new Solicitudes();

                // Llamar al método de registro
                int resultado = solicita.registrarSolicitud(peticion);

                if (resultado > 0)
                {
                    return Ok(new
                    {
                        titulo = "Éxito al guardar",
                        mensaje = "La solicitud se registró correctamente.",
                        codigo = 200
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        titulo = "Error al guardar",
                        mensaje = "No se pudo registrar la solicitud.",
                        codigo = 400
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    titulo = "Error del servidor",
                    mensaje = ex.Message,
                    detalles = ex.StackTrace,
                    codigo = 500
                });
            }
        }

        //Metodo para obtener la descripcion y foto dado el id_usuario 
        [HttpGet]
        [Route("descripcionFoto/{id_usuario}")]
        public List<string> obtenerInfo(int id_usuario)
        {

            //declaracion de objeto que retorna la foto y descripcion
            Versolicitudes verSoli = new Versolicitudes();

            //retorna la lista con la descripcion y ruta de la imagen
            return verSoli.obtenerDescripcion(id_usuario);

        }

        //Metodo para obtener el monto de la solicitud del cliente  dado el id_usuario
        [HttpGet]
        [Route("monto/{id_usuario}")]
        public double obtenerMonto(int id_usuario)
        {

            //declaracion de objeto que retorna la foto y descripcion
            Versolicitudes verMonto = new Versolicitudes();

            //retorna la lista con la descripcion y ruta de la imagen
            return verMonto.obtenerMonto(id_usuario);

        }

        //Metodo para obtener el nombre del usuario dado un id_solicitud
        [HttpGet]
        [Route("nombreSolicitante/{id_solicitud}")]
        public string obtenerId(int id_solicitud)
        {

            //declaracion de objeto que retorna la foto y descripcion
            Versolicitudes verNombre = new Versolicitudes();


            return verNombre.obtenernombresolicitante(id_solicitud);
        }




        /*
        //Metodo para retornar la lista de usuarios que han enviado solicitud 
        [HttpGet]
        [Route("listaSolicitantes")]
        public List<solicitudRequest> mostrarSolicitudes()
        {
            //declaracion de objeto de la clase que obtiene la informacion 
            Versolicitudes listaSolis = new Versolicitudes();

            return listaSolis.obtenerSolicitudes();
        }



        */
    }
}