namespace Rent.Domain.MessagePublishers
{
    public interface IMessagePublisher
    {
        Task PublishAsync(string topic, object message);
    }
}
