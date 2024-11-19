﻿using Microsoft.AspNetCore.Mvc;
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
        public object registrarSolicitud(Solicitud peticion)
        {
            //Clase que realiza el create
            Solicitudes pide = new Solicitudes();


            var guardado = pide.registrarSolicitud(peticion);

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


        //Metodo para obtener la descripcion y foto dado el id_usuario 
        [HttpGet]
        [Route("descripcionFoto")]
        public List<string> obtenerInfo(string id_usuario)
        {

            //declaracion de objeto que retorna la foto y descripcion
            Versolicitudes verSoli = new Versolicitudes();

            //retorna la lista con la descripcion y ruta de la imagen
            return verSoli.obtenerDescripcion(id_usuario);

        }

        //Metodo para obtener el monto de la solicitud del cliente  dado el id_usuario
        [HttpGet]
        [Route("monto")]
        public double obtenerMonto(string id_usuario)
        {

            //declaracion de objeto que retorna la foto y descripcion
            Versolicitudes verMonto = new Versolicitudes();

            //retorna la lista con la descripcion y ruta de la imagen
            return verMonto.obtenerMonto(id_usuario);

        }

        //Metodo para obtener el nombre del usuario dado un id_solicitud
        [HttpGet]
        [Route("nombreSolicitante")]
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