using Rent.Domain.MessagePublishers;

namespace Rent.Infra.Data.MessagePublishers
{
    public class MessagePublisher : IMessagePublisher
    {
        public async Task PublishAsync(string topic, object message)
        {
            Console.WriteLine($"Publishing to {topic}: {message}");
        }
    }
}
