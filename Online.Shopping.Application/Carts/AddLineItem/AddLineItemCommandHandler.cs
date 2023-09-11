using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Carts.AddLineItem;

internal sealed class AddLineItemCommandHandler : IRequestHandler<AddLineItemCommand, AddLineItemResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddLineItemCommandHandler(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddLineItemResponse> Handle(AddLineItemCommand addLineItemCommand, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(addLineItemCommand.CartId);

        if (cart is null)
             throw new CartNotFoundException(addLineItemCommand.CartId);

        var product = await _productRepository.GetByIdAsync(addLineItemCommand.ProductId);

        if (product is null)
           throw new ProductNotFoundException(addLineItemCommand.ProductId);

        cart.AddLineItem(product.Id, addLineItemCommand.Quantity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AddLineItemResponse(cart.LineItems);
    }
}
