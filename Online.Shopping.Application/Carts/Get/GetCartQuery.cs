using MediatR;

namespace Online.Shopping.Application.Carts.Get;

public record GetCartQuery(Guid CartId) : IRequest<CartResponse>;
