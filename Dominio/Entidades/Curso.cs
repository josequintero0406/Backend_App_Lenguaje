using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Curso
    {
        public int id_curso { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public double duracion { get; set; }
        public int id_plan { get; set; }
        public int id_contenido { get; set; }
        public int id_usuario { get; set; }
    }
}
