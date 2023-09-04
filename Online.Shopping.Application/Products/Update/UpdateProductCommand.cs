using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Update
{
    public record UpdateProductCommand(ProductId ProductId, string Name, decimal Price, int Sku) : IRequest;
}
