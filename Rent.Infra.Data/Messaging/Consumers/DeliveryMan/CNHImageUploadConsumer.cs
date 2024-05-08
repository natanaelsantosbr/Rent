using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Events;
using Rent.Domain.Events.DeliveryMan;
using Rent.Domain.Events.Motorycles;
using Rent.Domain.Models.ValueObjects.Settings;
using Rent.Infra.Data.Messaging.Base;
using System.Text;
using System.Text.Json;

namespace Rent.Infra.Data.Messaging.Consumers.Motorycles
{
    public class CNHImageUploadConsumer : EventConsumerBase
    {
        public CNHImageUploadConsumer(IModel channel, IServiceScopeFactory scopeFactory, ILogger logger, string nameEvent, IAppSettings appSettings)
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
                    await CMHImageUploadEvent(e);
                });
            };

            _channel.BasicConsume(_queueName, false, consumer);
        }

        private async Task CMHImageUploadEvent(BasicDeliverEventArgs e)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var content = Encoding.UTF8.GetString(e.Body.ToArray());
                _logger.LogInformation($"Received [{_queueName}]: {content}");

                try
                {
                    var notification = JsonSerializer.Deserialize<CNHImageUploadEvent>(e.Body.ToArray());

                    if (notification != null)
                    {
                        var filePath = Path.Combine(_appSettings.PathImageCNH, $"{Guid.NewGuid()}.png");

                        if (!Directory.Exists(_appSettings.PathImageCNH))
                            Directory.CreateDirectory(_appSettings.PathImageCNH);

                        await File.WriteAllBytesAsync(filePath, notification.ImageData);

                        var deliveryManRepository = _unitOfWork.ObterRepository<DeliveryMan>();

                        var deliveryMan = await deliveryManRepository.GetByIdAsync(notification.DeliveryMan);

                        if (deliveryMan != null)
                        {
                            deliveryMan.UpdateCNHImagePath(filePath);
                            await _unitOfWork.CommitAsync();
                        }
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
