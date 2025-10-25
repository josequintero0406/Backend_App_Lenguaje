using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Core.Interfaces.Servicios;

namespace Presentacion.Controllers
{
    [Route("api/curso")]
    [ApiController]
    public class CursoControlador : ControllerBase
    {
        /// <summary>
        /// Solo lectura
        /// </summary>
        private readonly ICursoServicio _cursoServicio;
        private readonly IProductorEventoServicio _productorEventoServicio;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursoServicio"></param>
        public CursoControlador(ICursoServicio cursoServicio, IProductorEventoServicio productorEventoServicio)
        {
            _cursoServicio = cursoServicio;
            _productorEventoServicio = productorEventoServicio;
        }

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="id_curso"></param>
        /// <returns></returns>
        [HttpGet("consultar")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Consultar([FromQuery] int id_curso)
        {
            var result = await _cursoServicio.ConsultarCurso(id_curso);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPost("insertar")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Insertar([FromBody] Curso curso)
        {
            var resultado = await _cursoServicio.InsertarCurso(curso);
            var eventoCRUD = new EventoCRUD
            {
                tipo_evento = "Inserción de datos",
                entidad_afectada = curso.nombre,
                id_usuario = curso.id_usuario.ToString(),
                detalles = $"Se ha realizado una inserción de un curso con ID: {resultado.id_curso}"
            };
            await _productorEventoServicio.ProducirEvento(eventoCRUD);
            return CreatedAtAction(nameof(Insertar), resultado);
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPut("modificar")]
        public async Task<IActionResult> Modificar([FromBody] Curso curso)
        {
            var result = await _cursoServicio.ModificarCurso(curso);
            if (result != null)
                return CreatedAtAction(nameof(Modificar), await _cursoServicio.ModificarCurso(curso));
            else
                return NotFound();
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id_curso"></param>
        /// <returns></returns>
        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromQuery] int id_curso)
        {
            return Ok("Curso eliminado correctamente: " + await _cursoServicio.EliminarCurso(id_curso));
        }
    }
}
