using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Carts;

namespace Online.Shopping.Application.Carts.RemoveLineItem;

internal sealed class RemoveLineItemCommandHandler : IRequestHandler<RemoveLineItemCommand, RemoveLineItemResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveLineItemCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RemoveLineItemResponse> Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId);

        if (cart is null)
        {
            return null;
        }

        cart.RemoveLineItem(request.LineItemId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RemoveLineItemResponse(cart.LineItems);
    }
}
