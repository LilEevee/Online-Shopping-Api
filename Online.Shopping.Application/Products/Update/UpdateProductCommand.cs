using MediatR;
using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Application.Products.Update
{
    public record UpdateProductCommand(ProductId ProductId, string Name, string Description, string Currency, decimal Price, int Sku) : IRequest<UpdateProductResponse>;
    public record UpdateProductRequest(Guid ProductId, string Name, string Description, string Currency, decimal Price, int Sku);
    public record UpdateProductResponse(Guid ProductId, string Name, string Description, string Currency, decimal Price, int Sku);
}
