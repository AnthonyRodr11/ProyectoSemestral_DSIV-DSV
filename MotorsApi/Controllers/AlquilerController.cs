
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Delete;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {

        [HttpGet]
        [Route("tarifas")]
        public List<TarifasAlquiler> ObtenerTarifas()
        {
            return new VerFlotas().obtenerTarifas();
        }

        [HttpPost]
        [Route("nueva/Tarifa")]
        public IActionResult registrarTarifa([FromBody] TarifasAlquiler tarifa)
        {
            if (tarifa == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            CrearTipoTarifa alquiler = new CrearTipoTarifa();
            var guardado = alquiler.crearnuevotipo(tarifa);

            if (guardado > 0)
            {
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
                    Mensaje = "El tipo de tarifa no pudo guardarse.",
                    Code = 500
                });
            }
        }

        [HttpPatch]
        [Route("editar/Tarifa/{id}")]
        public IActionResult actualizarTarifa(int id, [FromBody] TarifaRequest tarifas)
        {
            if (tarifas == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "El precio no puede ser nulo.",
                });
            }
            AlquilerAuto nuevoAlquiler = new AlquilerAuto();

            var actualizado = nuevoAlquiler.editarTarifa(id, tarifas);
            if (actualizado > 0)
            {
                return Ok(
                    new
                    {
                        titulo = "tarifa actualizada",
                        Mensaje = "El precio se ha actualizado correctamente",
                    }
                );
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "La tarifa no se pudo actualizar",
                });
            }
        }

        [HttpPost]
        [Route("registar")]
        public IActionResult alquilerNuevo([FromBody] AlquilerRequest alquiler)
        {

            Console.WriteLine("Datos Recibidos: " + JsonConvert.SerializeObject(alquiler));

            var guardado = new FlotaAlquilerInsert().InsertarAlquilado(alquiler);
            var cambiado = new VentaFlota().cambiarDisponibilidad(alquiler.placa, false);

            if (guardado > 0 && cambiado > 0)
            {
                return Ok(new
                {
                    titulo = "Éxito al guardar",
                    Mensaje = "Los datos se han guardado correctamente.",
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "El tipo de tarifa no pudo guardarse.",
                });
            }
        }

        [HttpGet]
        [Route("seguros")]
        public List<SeguroRequest> getSeguros()
        {
            return new SeguroRead().obtenerListaSeguros();
        }

        [HttpGet]
        [Route("auto/{placa}")]
        public IActionResult getAuto(string placa)
        {
            var auto = new AutoRequest().autoInfo(placa);
            if (auto == null)
                return NotFound("Carro no encontrado");
            return Ok(auto);
        }

        [HttpGet]
        [Route("alquiler")]
        public IActionResult obtenerAlquiler()
        {

            List<AlquilerCarrosRequest> guardar = new VerFlotas().alquileresAutos();

            if (guardar == null)
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron autos para el estado especificado.",
                    code = 404
                });
            return Ok(guardar);

        }



        [HttpGet]
        [Route("carros/alquiler")]
        public IActionResult obtenerTodosLosCarrines()
        {
            VerFlotas alquiler = new VerFlotas();

            var carros = alquiler.ObtenerTodosLos("alquiler");

            if (carros == null)
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


        [HttpPatch]
        [Route("alquiler/{estado}")]
        public IActionResult CambiarEstado(AlquilerRecue alquilersin, string estado)
        {
            Console.WriteLine($"Estado recibido: {estado}");

            if (alquilersin == null || alquilersin.id_vehiculo == null)
            {
                return BadRequest("Placa vacía");
            }

            var resultado = new AlquilerAuto().actualizarEstadoAlquiler(alquilersin, estado);

            if (resultado == null || resultado == 0)
            {
                return NotFound();
            }
            return Ok(resultado);
        }


        [HttpDelete]
        [Route("carros/alquiler/{placa}")]
        public IActionResult eliminarCarroAlquiler(string placa)
        {
            SubastaDeleter alquilersin = new SubastaDeleter();

            var carro = alquilersin.EliminarCarro(placa);

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

        [HttpGet]
        [Route("carros")]
        public IActionResult ObtenerTodosLosAutosMenosAlquiler()
        {
            VerFlotas todo = new VerFlotas();

            var autos = todo.ObtenerTodoMenos("alquiler");

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

    }
}
