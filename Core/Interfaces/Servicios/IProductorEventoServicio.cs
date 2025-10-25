using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Servicios
{
    public interface IProductorEventoServicio
    {
        Task ProducirEvento(EventoCRUD eventoCRUD);
    }
}
