using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class CursoServicio : ICursoServicio
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoServicio(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public async Task<List<Curso>> ConsultarCurso(int id_curso)
        {
            var result = await _cursoRepositorio.ConsultarCurso(id_curso);
            return result.Count != 0 ? result : null!;
        }

        public async Task<bool> EliminarCurso(int id_curso)
        {
            return await _cursoRepositorio.EliminarCurso(id_curso);
        }

        public async Task<Curso> InsertarCurso(Curso curso)
        {
            return await _cursoRepositorio.InsertarCurso(curso);
        }

        public async Task<Curso> ModificarCurso(Curso curso)
        {
            var result = await _cursoRepositorio.ModificarCurso(curso);
            return result != null ? result : null!;
        }
    }
}
