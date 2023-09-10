using MediatR;
using Online.Shopping.Domain.Carts;

namespace Online.Shopping.Application.Carts.RemoveLineItem;

public record RemoveLineItemCommand(CartId CartId, LineItemId LineItemId) : IRequest<RemoveLineItemResponse>;
public record RemoveLineItemRequest(Guid CartId, Guid LineItemId);
public record RemoveLineItemResponse(IReadOnlyList<LineItem> LineItemId);
