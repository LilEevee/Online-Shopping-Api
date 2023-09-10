using MediatR;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Create
{
    public record CreateProductCommand(string Name, string Description, string Currency, decimal Price, int Sku) : IRequest<CreateProductResponse>;
    public record CreateProductRequest(string Name, string Description, string Currency, decimal Price, int Sku);
    public record CreateProductResponse (Guid ProductId);
}
