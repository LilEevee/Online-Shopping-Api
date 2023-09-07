namespace Online.Shopping.Domain.Carts
{
    public record LineItemRemovedDomainEvent(Guid Id,CartId CartId,LineItemId LineItemId) : DomainEvent(Id);
}