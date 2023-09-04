using MediatR;

namespace Online.Shopping.Domain
{
    public record DomainEvent(Guid Id) : INotification;
}
