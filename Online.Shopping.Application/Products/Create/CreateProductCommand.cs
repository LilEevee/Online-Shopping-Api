using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Create
{
    public record CreateProductCommand(string Name, decimal Price, int Sku) : IRequest;
}
