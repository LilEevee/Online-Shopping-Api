using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Create
{
    public record CreateProductCommand(string Name, string Description, string Currency, decimal Price, int Sku, byte[] Image) : IRequest<CreateProductResponse>;
    public record CreateProductRequest(string Name, string Description, string Currency, decimal Price, int Sku, byte[] Image);
    public record CreateProductResponse (Guid ProductId);
}
