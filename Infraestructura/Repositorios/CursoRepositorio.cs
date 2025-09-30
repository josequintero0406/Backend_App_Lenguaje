using Core.Interfaces.Repositorios;
using Dominio.Entidades;
using Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        public readonly MySQL_Contexto _contexto;
        public CursoRepositorio(MySQL_Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Curso>> ConsultarCurso(int id_curso)
        {
            return await _contexto.curso
                .Where(item => item.id_curso == id_curso)
                .ToListAsync();
        }

        public async Task<bool> EliminarCurso(int id_curso)
        {
            var curso_existente = await _contexto.curso.FindAsync(id_curso);
            if (curso_existente == null)
                return false;
            _contexto.curso.Remove(curso_existente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<Curso> InsertarCurso(Curso curso)
        {
            _contexto.curso.Add(curso);
            await _contexto.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> ModificarCurso(Curso curso)
        {
            var curso_existente = await _contexto.curso.FindAsync(curso.id_curso);
            if (curso_existente == null)
                return null!;
            _contexto.Entry(curso_existente).CurrentValues.SetValues(curso);
            await _contexto.SaveChangesAsync();
            return await _contexto.curso.FindAsync(curso.id_curso);
        }
    }
}
