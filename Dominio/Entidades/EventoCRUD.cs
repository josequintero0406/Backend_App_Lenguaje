using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EventoCRUD
    {
        public string? tipo_evento { get; set; }
        public string? entidad_afectada { get; set; }
        public string? id_usuario { get; set; }
        public DateTime tiempo_ocurrencia { get; set; } = DateTime.Now;
        public string? detalles { get; set; }
    }
}
