using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Servicios
{
    public interface ICursoServicio
    {
        public Task<Curso> InsertarCurso(Curso curso);
        public Task<List<Curso>> ConsultarCurso(int id_curso);
        public Task<Curso> ModificarCurso(Curso curso);
        public Task<bool> EliminarCurso(int id_curso);
    }
}
