using MediatR;

namespace Online.Shopping.Application.Customers.Create
{
    public record CreateCustomerCommand (string Name, string Surname, string Email) : IRequest<CreateCustomerResponse>;
    public record CreateCustomerRequest (string Name, string Surname, string Email);
    public record CreateCustomerResponse(Guid CustomerId);
}
