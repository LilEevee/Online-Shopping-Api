using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Application.Carts.Create;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Carts.Create;

internal sealed class CreateCartCommandHandler : IRequestHandler<CreateCartCommand,CreateCartResponse>
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

    public async Task<CreateCartResponse> Handle(CreateCartCommand createCartCommand, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(
            new CustomerId(createCartCommand.CustomerId));

        if (customer is null)
            throw new CustomerNotFoundException(new CustomerId(createCartCommand.CustomerId));

        var cart = Cart.Create(customer.Id);

        _cartRepository.Add(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCartResponse(cart.Id.Value);
    }
}
