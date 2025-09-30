using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Contextos
{
    public class MySQL_Contexto : DbContext
    {
        public MySQL_Contexto(DbContextOptions<MySQL_Contexto> options)
            : base(options)
        {
        }

        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Curso> curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entidad =>
            {
                entidad.HasKey(e => e.id_usuario);
                entidad.HasIndex(e => e.id_usuario).IsUnique();
            });

            modelBuilder.Entity<Curso>(entidad =>
            {
                entidad.HasKey(e => e.id_curso);
                entidad.HasIndex(e => e.id_curso).IsUnique();
            });
        }
    }
}
