using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Read;

namespace MotorsApi.Controllers
{
    public class SubastaController : ControllerBase
    {

        [HttpGet]
        [Route("subasta/{placa}")]
        public IActionResult GetSubasta(string placa)
        {
            var tsubaru = new Ver_Flotas().listaSubasta(placa);

            if(tsubaru == null)
            {
                return NotFound("Error al cargar subasta");
            }
            return Ok(tsubaru);
        }


    }
}
