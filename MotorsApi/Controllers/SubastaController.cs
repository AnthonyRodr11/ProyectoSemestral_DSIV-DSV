using Microsoft.AspNetCore.Mvc;
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

    }
}
