using MediatR;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Carts.AddLineItem;

public record AddLineItemCommand(CartId CartId, ProductId ProductId, int Quantity) : IRequest<AddLineItemResponse>;

public record AddLineItemRequest(Guid CartId, Guid ProductId, int Quantity);

public record AddLineItemResponse(IReadOnlyList<LineItem> LineItemId);
