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
        //Metodo para registrar una Solicitud de venta en la BD
        [HttpPost]
        [Route("save")]                 //Objeto de clase que representa la entidad Solicitud 
        public async Task<IActionResult> registrarSolicitud([FromForm] IFormFile foto, [FromForm] string id_usuario, [FromForm] string descripcion, [FromForm] string estado, [FromForm] string monto)
        {
            // Ruta para guardar las imágenes
            string carpetaImagenes = Path.Combine(Directory.GetCurrentDirectory(), "MotorsValueWeb\\Img\\galeriaAutos");

            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaImagenes))
            {
                Directory.CreateDirectory(carpetaImagenes);
            }

            string nombreArchivo = null;

            if (foto != null && foto.Length > 0)
            {
                // Generar un nombre único para la imagen
                string extension = Path.GetExtension(foto.FileName);
                nombreArchivo = $"{Path.GetFileNameWithoutExtension(foto.FileName)}_{Guid.NewGuid()}{extension}";

                // Ruta completa para guardar la imagen
                string rutaArchivo = Path.Combine(carpetaImagenes, nombreArchivo);

                // Guardar la imagen en el servidor
                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    await foto.CopyToAsync(stream);
                }
            }

            // Crear la solicitud y guardar en la BD
            Solicitudes pide = new Solicitudes();

            var solicitud = new Solicitud
            {
                id_usuario = int.Parse(id_usuario),
                descripcion = descripcion,
                estado = estado,
                f_solicitud = DateTime.Now,
                foto = nombreArchivo, // Guardar solo el nombre del archivo en la base de datos
                monto = double.Parse(monto)
            };

            var guardado = pide.registrarSolicitud(solicitud);

            if (guardado > 0)
            {
                return Ok(new
                {
                    titulo = "Éxito al guardar",
                    Mensaje = "La solicitud se ha registrado correctamente.",
                    Code = 200
                });
            }
            return BadRequest(new
            {
                titulo = "Error al guardar",
                Mensaje = "Hubo un error al registrar la solicitud.",
                Code = 400
            });
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

        //Metodo para retornar la lista de usuarios que han enviado solicitud 
        [HttpGet]
        [Route("listaSolicitantes")]
        public List<solicitudRequest> mostrarSolicitudes()
        {
            //declaracion de objeto de la clase que obtiene la informacion 
            Versolicitudes listaSolis = new Versolicitudes();

            return listaSolis.obtenerSolicitudes();
        }
    }
}
