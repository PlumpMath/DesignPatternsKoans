using MassTransit;

namespace DomainModel.Events
{
    public interface IEventHandler<T> : IConsumer<T> where T : class, IDomainEvent
    {
        void Handle(T domainEvent);
    }
}