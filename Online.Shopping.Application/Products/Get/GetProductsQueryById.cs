using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Get
{
    public record GetProductQueryById(ProductId ProductId) : IRequest<ProductResponse>;
    public record ProductResponse(ProductId ProductId, string Name, decimal Price, int Sku);
}
