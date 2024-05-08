using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Models.ValueObjects.Settings;

namespace Rent.Infra.Data.Messaging.Base
{
    public abstract class EventConsumerBase : IEventConsumer
    {
        protected readonly IModel _channel;
        protected readonly IServiceScopeFactory _scopeFactory;
        protected readonly ILogger _logger;
        protected readonly string _queueName;
        protected readonly IAppSettings _appSettings;

        public EventConsumerBase(IModel channel, IServiceScopeFactory scopeFactory, ILogger logger, string queueName, IAppSettings appSettings)
        {
            _channel = channel;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _queueName = queueName;
            _appSettings = appSettings;
            DeclareQueue();
        }

        private void DeclareQueue()
        {
            if (_channel == null)
            {
                _logger.LogError($"Failed to connect to RabbitMQ create queue");
                return;
            }

            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _logger.LogInformation($"[{_queueName}] ok");
        }

        public abstract void StartConsuming();
    }
}
