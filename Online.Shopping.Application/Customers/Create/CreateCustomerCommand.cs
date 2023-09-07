using MediatR;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Customers.Create
{
    public record CreateCustomerCommand (string Name, string Email) : IRequest;
}
