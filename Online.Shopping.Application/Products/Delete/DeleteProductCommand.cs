using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Delete
{
    public record DeleteProductCommand (ProductId ProductId) : IRequest<DeleteProductResponse>;
    public record DeleteProductResponse(Guid ProductId, string Name, string Description, string Currency, decimal Price, int Sku);
}
