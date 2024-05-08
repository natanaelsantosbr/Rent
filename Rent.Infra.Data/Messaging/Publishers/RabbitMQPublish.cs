using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private readonly ILogger<RabbitMQPublish> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public RabbitMQPublish(IAppSettings appSettings, ILogger<RabbitMQPublish> logger, IServiceScopeFactory scopeFactory)
        {
            _appSettings = appSettings;
            _logger = logger;
            _scopeFactory = scopeFactory;

            var factory = new ConnectionFactory()
            {
                HostName = _appSettings.RabbitMq.HostName
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.MotorcycleRegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.CNHImageEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send to the queue. {ex.Message}");
            }
        }

        public async void Publish<T>(string name, T @event) where T : class
        {
            var queueName = name;
            var json = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(json);

            try
            {   
                _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to send to the queue : {queueName} body: {json} ex: {ex.Message}");

                using (var scope = _scopeFactory.CreateScope())
                {
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var eventFailedRepository = _unitOfWork.ObterRepository<EventFailed>();

                    var eventFailed = new EventFailed(queueName, json, ex.Message, ex.StackTrace);

                    await eventFailedRepository.AddAsync(eventFailed);

                    await _unitOfWork.CommitAsync();
                }
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
