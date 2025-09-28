using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Servicios
{
    public interface IUsuarioServicio
    {
        public Task<Usuario> InsertarUsuario(Usuario usuario);
        public Task<List<Usuario>> ConsultarUsuario(string email);
        public Task<Usuario> ModificarUsuario(Usuario usuario);
        public Task<bool> EliminarUsuario(int id_usuario);
    }
}
