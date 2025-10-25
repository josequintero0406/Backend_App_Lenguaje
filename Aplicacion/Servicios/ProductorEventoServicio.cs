using Confluent.Kafka;
using Core.Interfaces.Servicios;
using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ProductorEventoServicio : IProductorEventoServicio
    {
        private readonly IProducer<Null, string> _producer;
        private const string Topic = "log-crud-events";

        public ProductorEventoServicio()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProducirEvento(EventoCRUD eventoCRUD)
        {
            var serializado = JsonSerializer.Serialize(eventoCRUD);
            try
            {
                var reporteEntrega = await _producer.ProduceAsync(
                    Topic, new Message<Null, string> { Value = serializado }
                );
                Console.WriteLine($"Evento entregado al tópico: {reporteEntrega.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Error al enviar el evento: {e.Error.Reason}");
            }
        }
    }
}
