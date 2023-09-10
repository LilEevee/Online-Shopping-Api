using MediatR;
using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Application.Products.Get
{
    public record GetProductQueryById(ProductId ProductId) : IRequest<ProductResponse>;
    public record ProductResponse(ProductId ProductId, string Name, string Currency , decimal Price, int Sku);
}
