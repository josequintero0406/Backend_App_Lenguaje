using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
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
    public class LogEventoRepositorio : ILogEventoRepositorio
    {
        public readonly MySQL_Contexto _contexto;

        public LogEventoRepositorio(MySQL_Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<LogEvento> GuardarLog(LogEvento logEvento)
        {
            _contexto.log_evento.Add(logEvento);
            await _contexto.SaveChangesAsync();
            return logEvento;
        }
    }
}
