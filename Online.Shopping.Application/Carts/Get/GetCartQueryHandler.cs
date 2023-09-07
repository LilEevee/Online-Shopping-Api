using MediatR;
using Microsoft.EntityFrameworkCore;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Carts;

namespace Online.Shopping.Application.Carts.Get;

internal sealed class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartResponse>
{
    private readonly IOnlineShoppingDbContext _onlineShoppingDbContext;

    public GetCartQueryHandler(IOnlineShoppingDbContext onlineShoppingDbContext)
    {
        _onlineShoppingDbContext = onlineShoppingDbContext;
    }

    public async Task<CartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cartId = new CartId(request.CartId);

        var cartResponse = await _onlineShoppingDbContext
            .Carts
            .Where(o => o.Id == cartId)
            .Select(o => new CartResponse(
                o.Id.Id,
                o.CustomerId.Id,
                o.LineItems
                    .Select(li => new LineItemResponse(li.LineItemId.Id, li.Price.Amount))
                    .ToList()))
            .FirstOrDefaultAsync(cancellationToken);

        if (cartResponse is null)
        {
            throw new Exception();
        }

        return cartResponse;
    }
}
