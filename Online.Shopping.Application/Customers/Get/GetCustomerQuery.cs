using MediatR;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Customers.Get
{
    public record GetCustomerQuery(CustomerId CustomerId) : IRequest<CustomerResponse>;
    public record CustomerResponse(CustomerId CustomerId, string Email, string Name);

}
