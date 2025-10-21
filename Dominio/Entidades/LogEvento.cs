using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class LogEvento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? TipoEvento { get; set; }
        public string? Carga { get; set; }
        public DateTime FechaYHora { get; set; } = DateTime.UtcNow;
        public bool Procesado { get; set; } = false;
        public DateTime? FechaYHoraProceso { get; set; }
    }
}
