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
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<List<Usuario>> ConsultarUsuario(string email)
        {
            var result = await _usuarioRepositorio.ConsultarUsuario(email);
            return result.Count != 0 ? result : null!;
        }

        public async Task<bool> EliminarUsuario(int id_usuario)
        {
            return await _usuarioRepositorio.EliminarUsuario(id_usuario);
        }

        public async Task<Usuario> InsertarUsuario(Usuario usuario)
        {
            return await _usuarioRepositorio.InsertarUsuario(usuario);
        }

        public async Task<Usuario> ModificarUsuario(Usuario usuario)
        {
            var result = await _usuarioRepositorio.ModificarUsuario(usuario);
            return result != null ? result : null!;
        }
    }
}
