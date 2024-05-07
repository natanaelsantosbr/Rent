using Flunt.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Events;
using Rent.Domain.Events.Motorycles;
using Rent.Infra.Data.Messaging.Consumers;
using Rent.Infra.Data.Messaging.Consumers.Motorycles;
using Rent.Infra.Data.Repositories.DeliveryMen;
using Rent.Infra.Data.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Messaging
{
    public class RabbitMQConsumerService : BackgroundService
    {
        private readonly IAppSettings _appSettings;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RabbitMQConsumerService> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQConsumerService(IServiceScopeFactory scopeFactory, ILogger<RabbitMQConsumerService> logger, IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _scopeFactory = scopeFactory;
            _logger = logger;

            var factory = new ConnectionFactory()
            {
                HostName = appSettings.RabbitMq.HostName,
                Port = appSettings.RabbitMq.Port,
                UserName = appSettings.RabbitMq.UserName,
                Password = appSettings.RabbitMq.Password
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer1 = new MotorcycleRegisteredConsumer(_channel, _scopeFactory, _logger, _appSettings.RabbitMq.Events.MotorcycleRegisteredEvent);
            var consumer2 = new Motorcycle2024RegisteredConsumer(_channel, _scopeFactory, _logger, _appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent);

            consumer1.StartConsuming();
            consumer2.StartConsuming();

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
