using Confluent.Kafka;
using Core.Interfaces.Servicios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class LogEventoServicio : ILogEventoServicio
    {
        private readonly IProducer<Null, string> _producer;

        public LogEventoServicio(IConfiguration config)
        {
            var conf = new ProducerConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<Null, string>(conf).Build();
        }
        public async Task SendLogAsync(string message)
        {
            await _producer.ProduceAsync("api-logs", new Message<Null, string> { Value = message });
        }

    }
}
