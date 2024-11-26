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
        public IActionResult GetSubasta(int placa)
        {
            var tsubaru = new Ver_Flotas().listaSubasta(placa);

            if(tsubaru == null)
            {
                return NotFound("Error al cargar subasta");
            }
            return Ok(tsubaru);
        }

        [HttpPatch]
        [Route("pujar")]
        public IActionResult HacerPuja(int id, [FromBody] SubastaRequest ludopatia)
        {
            if (ludopatia == null)
            {
                return NotFound("Error al Pujar a la subasta");
            }

            var apuesta = new Pujar().InsertarPuja(id, ludopatia);
            if (apuesta > 0)
                return Ok();

            return StatusCode(418);

        }
    }
}
