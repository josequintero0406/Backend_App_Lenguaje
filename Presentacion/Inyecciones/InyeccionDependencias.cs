using Microsoft.EntityFrameworkCore;
using Aplicacion.Servicios;
using Core.Interfaces.Servicios;
using Core.Interfaces.Repositorios;
using Infraestructura.Contextos;
using Infraestructura.Repositorios;

namespace Api.Inyecciones
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            // Agregar el contexto de la base de datos MySQL
            servicios.AddDbContext<MySQL_Contexto>(opciones =>
            {
                opciones.UseMySql(configuracion.GetConnectionString("MySQL"), 
                    ServerVersion.AutoDetect(configuracion.GetConnectionString("MySQL")));
            });

            //Agregar los repositorios
            servicios.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            //Agregar los servicios
            servicios.AddTransient<IUsuarioServicio, UsuarioServicio>();

            servicios.AddSingleton<IConfiguration>(configuracion);

            return servicios;
        }
    }
}
