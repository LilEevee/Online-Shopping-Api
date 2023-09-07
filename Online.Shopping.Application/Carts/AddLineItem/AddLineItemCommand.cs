using MediatR;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Carts.AddLineItem;

public record AddLineItemCommand(CartId CartId, ProductId ProductId, string Currency, decimal Amount) : IRequest;

public record AddLineItemRequest(Guid CartId, Guid ProductId, string Currency, decimal Amount);
