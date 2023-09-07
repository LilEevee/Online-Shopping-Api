using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(new CustomerId(Guid.NewGuid()), request.Email, request.Name);

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken); 
        }
    }
}
