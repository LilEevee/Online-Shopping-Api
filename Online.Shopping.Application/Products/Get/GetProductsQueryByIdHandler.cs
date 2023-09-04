using MediatR;
using Microsoft.EntityFrameworkCore;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Get
{
    internal sealed class GetProductsQueryByIdHandler : IRequestHandler<GetProductQueryById, ProductResponse>
    {
        private readonly IOnlineShoppingDbContext _onlineShoppingDbContext;
        public GetProductsQueryByIdHandler(IOnlineShoppingDbContext onlineShoppingDbContext)
        {
            _onlineShoppingDbContext = onlineShoppingDbContext;
        }
        public async Task<ProductResponse> Handle(GetProductQueryById request, CancellationToken cancellationToken)
        {
            var product = await _onlineShoppingDbContext
                .Products
                .Where(p => p.Id == request.ProductId)
                .Select(p => new ProductResponse(p.Id, p.Name, p.Price, p.Sku))
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null)
            {
                // TODO: ADD EXCEPTION HANDLING
                throw new ArgumentException();
            }

            return product;
        }
    }
}
