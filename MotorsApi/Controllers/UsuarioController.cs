using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Delete;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;

namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route ("user/new")]
        public IActionResult registrarUsuario([FromBody] RegistroUsuario personita)
        {
            if(personita == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            RegistrandoUsuario registro = new RegistrandoUsuario();
            var guardar = registro.CreandoRegistro(personita);
            

            if (guardar > 0)
            {
                return Ok( new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "Error al crear el usuario.",
                    Code = 500
                });
            }
        }

        [HttpDelete]
        [Route ("user/delete/{id}")]
        public IActionResult eliminarUsuario(int id)
        {
            if(id == 0)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            EliminarRol borradorcito = new EliminarRol();

            if (borradorcito.rolEliminar(id)>0)
            {
                return Ok(new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
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
        [Route ("user/update/{correo}")]
        public IActionResult actualizarUsuario(string correo, [FromBody] ActualizarUsuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            EditarUsuario itadori = new EditarUsuario(); 
            var guarda = itadori.editarUsuario(correo, usuario);

            if (guarda > 0)
            {
                return Ok(new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {   
                    titulo = "Error al Editar",
                    Mensaje = "no se pudo guardar.",
                    Code = 500
                });
            }
        }

        


        [HttpGet]
        [Route("user/login/{correo}/{contraseña}")]
        public IActionResult logearUsuario(string correo, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "Debe proporcionar correo y contraseña.",
                    Code = 400
                });
            }

            Loggearse lojin = new Loggearse();
            var cuera = lojin.verificarLogin(correo, contraseña);

            if (cuera>0)
            {
                return Ok(cuera);
            }
            else
            {
                return Unauthorized(new
                {
                    titulo = "Error de autenticación",
                    Mensaje = "El correo o la contraseña son incorrectos.",
                    Code = 401
                });
            }
        }

        [HttpGet]
        [Route("user/email/{correo}")]
        public IActionResult verificarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "Debe proporcionar correo valido",
                });
            }

            Loggearse lojin = new Loggearse();
            var cuera = lojin.verificarCorreo(correo);

            if (cuera)
            {
                return Ok(cuera);
            }
            else
            {
                return Unauthorized(new
                {
                    titulo = "Error de autenticación",
                    Mensaje = "El correo no se encuentra registrado",
                });
            }
        }

        //Metodo para obtener el nombre, apellido,correo, telefono 
        [HttpGet]
        [Route("userInfo/{id}")]
        public IActionResult mostrarInfo(int id)
        {
            Loggearse cliente = new Loggearse();
            var usuario = cliente.obtenerUsuario(id);

            if (usuario == null || usuario.Count == -1)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron los datos del usuario",
                    code = 404
                });
            }
            return Ok(usuario);

        }

    }
}
