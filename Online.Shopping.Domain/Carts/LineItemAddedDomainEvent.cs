namespace Online.Shopping.Domain.Carts
{
    public sealed record LineItemAddedDomainEvent(Guid Id, CartId CartId, LineItemId LineItemId) : DomainEvent(Id);
}