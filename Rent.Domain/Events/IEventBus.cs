namespace Rent.Application.Events
{
    public interface IEventBus
    {
        void Publish<T>(string name, T @event) where T : class;
    }
}
