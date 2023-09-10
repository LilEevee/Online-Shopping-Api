using MediatR;

namespace Online.Shopping.Application.Carts.Create;

public record CreateCartCommand(Guid CustomerId) : IRequest<CreateCartResponse>;
public record CreateCartResponse(Guid CartId);
