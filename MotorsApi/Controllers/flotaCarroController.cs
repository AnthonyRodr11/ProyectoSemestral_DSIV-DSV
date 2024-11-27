using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;
namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class flotaCarroController : ControllerBase
    {
        [HttpPost]
        [Route("save")]
        public object registrarAuto(FlotaCarro autos)
        {

            FlotaAuto regAuto = new FlotaAuto();

            var guardado = regAuto.registraAutoflota(autos);

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

        [HttpPatch]
        [Route("update/state")]
        public object actualizarEstado(UpdateState carrito) //Este sirve para mover un auto de Subasta hacia Ventas o Alquiler
        {
            AlquilerAuto alquiler = new AlquilerAuto();

            var guardado = alquiler.ActualizarEstado(carrito);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al Guardar",
                    mensaje = "Los datos se han guardado Correctamente",
                    code = 200
                };
            return new
            {
                titulo = "Error al Guardar",
                mensaje = "No se encontraron tus datos :c",
                code = 400
            };

        }

        [HttpPost]
        [Route("create/subasta")]
        public object registrarSubastaCarro(AgregarSubasta carrito)//Este sirve para crear un carro en subasta.
        {
            SubastaFlota subastita = new SubastaFlota();

            var guardado = subastita.registrarSubastaCarro(carrito);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al Guardar",
                    mensaje = "Los datos se han guardado Correctamente",
                    code = 200
                };
            return new
            {
                titulo = "Error al Guardar",
                mensaje = "No se encontraron tus datos :c",
                code = 400
            };
        }


        //Metodo para obtener la lista de carroceria para venta, alquiler, subasta {mandas el estado}
        [HttpGet]
        [Route("verCarroceria/{estado}")]
        public IActionResult obtenerCarrocerias(string estado)
        {
            VerFlotas flotas = new VerFlotas();
            var carrocerias = flotas.listaCarroceria(estado);

            if (carrocerias == null || carrocerias.Count == 0)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron carrocerías para el estado especificado.",
                    code = 404
                });
            }
            return Ok(carrocerias);
        }





        [HttpGet]
        [Route("ofertaActual/{cod_subasta}")]
        public IActionResult obtenerActualOferta(int cod_subasta)
        {
            VerFlotas ver_Flotas = new VerFlotas();
            var oferta = ver_Flotas.obtenerOfertaActual(cod_subasta);


            if (oferta == null )
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 404
                });
            }

            return Ok(oferta);
        }


        //Controlador para obtener la lista de autos que estan en subasta
        [HttpGet]
        [Route("listaSubasta")]
        public IActionResult obtenerAutosSubasta()
        {

            VerFlotas enSubasta = new VerFlotas();

            var autos = enSubasta.listaSubasta();

            if (autos == null)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 404
                });
            }

            return Ok(autos);
        }
    }


}
