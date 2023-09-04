using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Delete
{
    public record DeleteProductCommand (ProductId ProductId) : IRequest;
}
