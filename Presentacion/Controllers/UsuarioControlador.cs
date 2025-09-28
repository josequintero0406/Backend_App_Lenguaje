using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controladores
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioControlador : ControllerBase
    {
        /// <summary>
        /// Solo lectura
        /// </summary>
        private readonly IUsuarioServicio _usuarioServicio;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="usuarioServicio"></param>
        public UsuarioControlador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="id_usuario"></param>
        /// <returns></returns>
        [HttpGet("consultar")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Consultar([FromQuery] string email)
        {
            var result = await _usuarioServicio.ConsultarUsuario(email);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("insertar")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Insertar([FromBody] Usuario usuario)
        {
            return CreatedAtAction(nameof(Insertar), await _usuarioServicio.InsertarUsuario(usuario));
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("modificar")]
        public async Task<IActionResult> Modificar([FromBody] Usuario usuario)
        {
            var result = await _usuarioServicio.ModificarUsuario(usuario);
            if (result != null)
                return CreatedAtAction(nameof(Modificar), await _usuarioServicio.ModificarUsuario(usuario));
            else
                return NotFound();
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id_usuario"></param>
        /// <returns></returns>
        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromQuery] int id_usuario)
        {
            return Ok("Usuario eliminado correctamente: " + await _usuarioServicio.EliminarUsuario(id_usuario));
        }
    }
}
