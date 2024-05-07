using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Rent.Infra.Data.Messaging.Base
{
    public abstract class EventConsumerBase : IEventConsumer
    {
        protected readonly IModel _channel;
        protected readonly IServiceScopeFactory _scopeFactory;
        protected readonly ILogger _logger;
        protected readonly string _queueName;

        public EventConsumerBase(IModel channel, IServiceScopeFactory scopeFactory, ILogger logger, string queueName)
        {
            _channel = channel;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _queueName = queueName;
            DeclareQueue();
        }

        private void DeclareQueue()
        {
            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _logger.LogInformation($"[{_queueName}] ok");
        }

        public abstract void StartConsuming();
    }
}
