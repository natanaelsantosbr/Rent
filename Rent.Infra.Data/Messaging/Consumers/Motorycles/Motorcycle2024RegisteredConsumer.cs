using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Events;
using Rent.Domain.Events.Motorycles;
using Rent.Infra.Data.Messaging.Base;
using System.Text;
using System.Text.Json;

namespace Rent.Infra.Data.Messaging.Consumers.Motorycles
{
    public class Motorcycle2024RegisteredConsumer : EventConsumerBase
    {
        public Motorcycle2024RegisteredConsumer(IModel channel, IServiceScopeFactory scopeFactory, ILogger logger, string nameEvent, IAppSettings appSettings)
            : base(channel, scopeFactory, logger, nameEvent, appSettings)
        {
        }

        public override void StartConsuming()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                Task.Run(async () =>
                {
                    await Motorcycle2024RegisteredEvent(e);
                });
            };

            _channel.BasicConsume(_queueName, false, consumer);
        }

        private async Task Motorcycle2024RegisteredEvent(BasicDeliverEventArgs e)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var content = Encoding.UTF8.GetString(e.Body.ToArray());
                _logger.LogInformation($"Received [{_queueName}]: {content}");

                try
                {
                    var notification = JsonSerializer.Deserialize<MotorcycleRegisteredEvent>(e.Body.ToArray());

                    if (notification != null)
                    {
                        var name = $"Motorcycle 2024 registered {notification.Motorcycle.Id} {notification.Motorcycle.Model}";
                        var @event = new Event(name, DateTime.Now);

                        var eventRepository = _unitOfWork.ObterRepository<Event>();
                        await eventRepository.AddAsync(@event);

                        await _unitOfWork.CommitAsync();
                    }

                    _channel.BasicAck(e.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Error processing message: {ex.Message}");
                    _channel.BasicNack(e.DeliveryTag, false, true);
                }
            }
        }
    }
}
