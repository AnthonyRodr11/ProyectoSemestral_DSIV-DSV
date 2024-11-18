﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
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
        public object registrarAuto(Flota_Carro autos)
        {
            
            Flota_Auto regAuto = new Flota_Auto();

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
        public object ActualizarEstado(Update_State carrito) //Este sirve para mover un auto de Subasta hacia Ventas o Alquiler
        {
            Alquiler_Auto alquiler = new Alquiler_Auto();

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
            Subasta_Flota subastita = new Subasta_Flota();

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

    }
}
