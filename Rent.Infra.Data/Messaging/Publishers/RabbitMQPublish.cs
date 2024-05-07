using RabbitMQ.Client;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Messaging.Publishers
{
    public class RabbitMQPublish : IEventBus, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IAppSettings _appSettings;

        public RabbitMQPublish(IAppSettings appSettings)
        {
            _appSettings = appSettings;

            var factory = new ConnectionFactory()
            {
                HostName = _appSettings.RabbitMq.HostName
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.MotorcycleRegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Publish<T>(string name, T @event) where T : class
        {
            var queueName = name;
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
            _channel.BasicPublish(exchange: "", routingKey: queueName.ToLower(), basicProperties: null, body: body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
