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
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RabbitMQConsumerService> _logger;
        private readonly IAppSettings _appSettings;

        public RabbitMQConsumerService(IServiceScopeFactory scopeFactory, ILogger<RabbitMQConsumerService> logger, IAppSettings appSettings)
        {
            _appSettings = appSettings;

            var factory = new ConnectionFactory()
            {
                HostName = _appSettings.RabbitMq.HostName,
                Port = _appSettings.RabbitMq.Port,
                UserName = _appSettings.RabbitMq.UserName,
                Password = _appSettings.RabbitMq.Password
            };


            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _scopeFactory = scopeFactory;
            _logger = logger;

            _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.MotorcycleRegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: _appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("BackgroundService on");

            stoppingToken.ThrowIfCancellationRequested();

            var consumer1 = new EventingBasicConsumer(_channel);
            consumer1.Received += async (ch, ea) =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    _logger.LogInformation($"Received [${_appSettings.RabbitMq.Events.MotorcycleRegisteredEvent}]: {content}");

                    try
                    {
                        var notification = JsonSerializer.Deserialize<MotorcycleRegisteredEvent>(ea.Body.ToArray());

                        if (notification != null)
                        {
                            var name = $"Motorcycle registered {notification.Motorcycle.Id} {notification.Motorcycle.Model}";
                            var @event = new Event(name, DateTime.Now);

                            var eventRepository = _unitOfWork.ObterRepository<Event>();
                            await eventRepository.AddAsync(@event);

                            await _unitOfWork.CommitAsync();
                        }

                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation($"Error processing message: {ex.Message}");
                        _channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                }
            };

            _channel.BasicConsume(_appSettings.RabbitMq.Events.MotorcycleRegisteredEvent, false, consumer1);

            var consumer2 = new EventingBasicConsumer(_channel);
            consumer2.Received += async (ch, ea) =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    _logger.LogInformation($"Received [${_appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent}] : {content}");

                    try
                    {
                        var notification = JsonSerializer.Deserialize<MotorcycleRegisteredEvent>(ea.Body.ToArray());

                        if (notification != null)
                        {
                            var name = $"Motorcycle registered 2024 {notification.Motorcycle.Id} {notification.Motorcycle.Model}";
                            var @event = new Event(name, DateTime.Now);

                            var eventRepository = _unitOfWork.ObterRepository<Event>();

                            await eventRepository.AddAsync(@event);

                            await _unitOfWork.CommitAsync();

                            _channel.BasicAck(ea.DeliveryTag, false);
                        }


                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation($"Error processing message: {ex.Message}");
                        _channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                }

            };

            _channel.BasicConsume(_appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent, false, consumer2);

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
