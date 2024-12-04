using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Delete;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;

namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class SubastaController : ControllerBase
    {

        [HttpGet]
        [Route("subasta/{placa}")]
        public IActionResult getSubasta(int placa)
        {
            var tsubaru = new VerFlotas().listaSubasta(placa);

            if(tsubaru == null)
            {
                return NotFound("Error al cargar subasta");
            }
            return Ok(tsubaru);
        }

        [HttpPatch]
        [Route("pujar")]
        public IActionResult hacerPuja([FromBody] SubastaRequest request)
        {
            if (request == null || request.valor_puja == null || request.usuario == null)
            {
                return BadRequest("Datos incompletos para realizar la puja.");
            }

            var resultado = new Pujar().insertarPuja(request);

            if (resultado == null || resultado == 0)
                return StatusCode(418, "Puja rechazada o no fue procesada.");

            return Ok("Puja realizada correctamente.");
        }

        [HttpGet]
        [Route("placa/{cod_subasta}")]
        public IActionResult getPlaca(int cod_subasta)
        {
            var guardar = new Pujar().GetPlaca(cod_subasta);

            if (guardar == null)
            {
                return NotFound();
            }
            return Ok(guardar);
        }

        [HttpPatch]
        [Route("subasta")]
        public IActionResult CambiarEstado(AgregarSubasta subastita)
        {
            if (subastita == null || subastita.id_placa == null)
            {
                return BadRequest("Placa vacía");
            }

            var resultado = new SubastaUpdate().ActualizarEstadoSubasta(subastita);

            if(resultado == null || resultado == 0)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpPatch]
        [Route("subasta/{estado}")]
        public IActionResult CambiarEstado(AgregarSubasta subastita, string estado)
        {
            Console.WriteLine($"Estado recibido: {estado}");

            if (subastita == null || subastita.id_placa == null)
            {
                return BadRequest("Placa vacía");
            }

            var resultado = new SubastaUpdate().ActualizarEstadoSubasta(subastita, estado);

            if (resultado == null || resultado == 0)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpGet]
        [Route("carros")]
        public IActionResult ObtenerTodosLosAutosMenosSubasta()
        {
            VerFlotas todo = new VerFlotas();

            var autos = todo.ObtenerTodoMenosSubasta();

            if (autos == null)
            {
                return NotFound(new
                {
                    titulo = "No se encontraron autos",
                    mensaje = "Ningun auto encontrado",
                    code = 404
                });
            }

            return Ok(autos);
        }

        [HttpGet]
        [Route("carros/subasta")]
        public IActionResult ObtenerTodosLosAutosSubasta()
        {
            VerFlotas subasta = new VerFlotas();

            var carros = subasta.ObtenerTodaSubasta();

            if(carros == null)
            {
                return NotFound(new
                {
                    titulo = "No se encontraron autos",
                    mensaje = "Ningun auto encontrado",
                    code = 404
                });
            }

            return Ok(carros);
        }

        [HttpDelete]
        [Route("carros/subasta/{placa}")]
        public IActionResult EliminarCarroDeSubasta(string placa)
        {
            SubastaDeleter subasta = new SubastaDeleter();

            var carro = subasta.EliminarCarro(placa);

            if (carro == null)
            {
                return NotFound(new
                {
                    titulo = "No se encontraron autos",
                    mensaje = "Ningun auto encontrado",
                    code = 404
                });
            }
            return Ok(carro);
        }

    }
}
