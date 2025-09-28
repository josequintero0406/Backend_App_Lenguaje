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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public readonly MySQL_Contexto _contexto;
        public UsuarioRepositorio(MySQL_Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Usuario>> ConsultarUsuario(string email)
        {
            return await _contexto.usuario
                .Where(item => item.email == email)
                .ToListAsync();
        }

        public async Task<bool> EliminarUsuario(int id_usuario)
        {
            var usuario_existente = await _contexto.usuario.FindAsync(id_usuario);
            if (usuario_existente == null)
                return false;
            _contexto.usuario.Remove(usuario_existente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> InsertarUsuario(Usuario usuario)
        {
            _contexto.usuario.Add(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ModificarUsuario(Usuario usuario)
        {
            var carro_existente = await _contexto.usuario.FindAsync(usuario.id_usuario);
            if (carro_existente == null)
                return null!;
            _contexto.Entry(carro_existente).CurrentValues.SetValues(usuario);
            await _contexto.SaveChangesAsync();
            return await _contexto.usuario.FindAsync(usuario.id_usuario);
        }
    }
}
