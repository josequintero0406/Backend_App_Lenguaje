using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Core.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio
    {
        public Task<Usuario> InsertarUsuario(Usuario usuario);
        public Task<List<Usuario>> ConsultarUsuario(string email);
        public Task<Usuario> ModificarUsuario(Usuario usuario);
        public Task<bool> EliminarUsuario(int id_usuario);
    }
}
