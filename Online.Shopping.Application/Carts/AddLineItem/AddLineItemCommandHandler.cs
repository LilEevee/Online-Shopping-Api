using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Carts.AddLineItem;

internal sealed class AddLineItemCommandHandler : IRequestHandler<AddLineItemCommand>
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

    public async Task Handle(AddLineItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId);

        if (cart is null)
        {
            // throw new CartNotFoundException(request.CartId);
            throw new Exception();
        }

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            throw new Exception();
            // throw new ProductNotFoundException(request.ProductId);
        }

        cart.AddLineItem(product.Id, new Price(request.Currency, request.Amount));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
