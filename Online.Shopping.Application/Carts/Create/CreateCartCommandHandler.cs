using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Application.Carts.Create;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Carts.Create;

internal sealed class CreateCartCommandHandler : IRequestHandler<CreateCartCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCartCommandHandler(
        ICustomerRepository customerRepository,
        ICartRepository cartRepository,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(
            new CustomerId(request.CustomerId));

        if (customer is null)
        {
            return;
        }

        var cart = Cart.Create(customer.Id);

        _cartRepository.Add(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
