namespace Online.Shopping.Domain.Carts
{
    public record CartCreatedDomainEvent(Guid Id, CartId CartId) : DomainEvent(Id);
}