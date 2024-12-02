using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.Models;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.BD.CRUD.Read;

namespace MotorsApi.Controllers
{

    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class ventaFlotaController : ControllerBase
    {

        [HttpPost]
        [Route("venta")] 
        public object venderAuto(Ventas venta) //Este método agrega a la tabla Flota_Venta, el carro pasa a venderse
        {
            VentaFlota ventaAuto = new VentaFlota();

            var guardado = ventaAuto.registrarVenta(venta);

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



        [HttpGet]
        [Route("listaFlota/{estado}")]
        public IActionResult listaAutos(string estado)
        {
            VerFlotas autos = new VerFlotas();
            var listaautos = autos.tiposFlota(estado);

            if ( listaautos == null || listaautos.Count == 0)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron carrocerías para el estado especificado.",
                    code = 404
                });
            }

            return Ok(listaautos);
        }

        [HttpGet]
        [Route("ventaId/{placa}")]
        public IActionResult listaVenta(string placa)
        {
            VentaFlota ventaId = new VentaFlota();
            int? id = ventaId.obtenerVentaIdporPlaca(placa);
            if (id == null)
            {
                return BadRequest(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontro ningun id",
                });
            }

            return Ok(id);
        }

        [HttpGet]
        [Route("flotaDetalle/{id}")]
        public IActionResult listaAutosPerfil(string id)
        {
            VerFlotas autos = new VerFlotas();
            var listaautos = autos.flotaVenta(id);

            if (listaautos == null || listaautos.Count == 0)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron carrocerías para el estado especificado.",
                    code = 404
                });
            }

            return Ok(listaautos);
        }

        [HttpPost]
        [Route ("vendido")]
        public IActionResult carroVendido([FromBody] FlotaVenta vendido)
        {
            if (vendido == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "Datos o id nulos",
                    Code = 400
                });
            }

            VentaFlota agregar = new VentaFlota();
            bool dispo = false;

            var guardado = agregar.venderCarro(vendido); //Para saber si se ingresaron los datos
             //para saber si se cambió la disponibilidad

            if (guardado > 0)
            {
                var cambiado = agregar.cambiarDisponibilidad(vendido.placa, dispo);
                return Ok(new
                {
                    titulo = "Éxito al guardar",
                    Mensaje = "Los datos se han guardado correctamente.",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "El carro no se pudo vender.",
                    Code = 500
                });
            }
            }


    }
}
