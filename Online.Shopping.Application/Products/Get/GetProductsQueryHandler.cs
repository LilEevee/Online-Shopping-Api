using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Get
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedList<ProductResponse>>
    {
        private readonly IOnlineShoppingDbContext _onlineShoppingDbContext;

        public GetProductsQueryHandler(IOnlineShoppingDbContext onlineShoppingDbContext)
        {
            _onlineShoppingDbContext = onlineShoppingDbContext;
        }

        public async Task<PagedList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> productsQuery = _onlineShoppingDbContext.Products;

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                productsQuery = productsQuery
                            .Where(p => p.Name.Contains(request.SearchTerm));
            }

            var productResponsesQuery = productsQuery
                        .Select(p => new ProductResponse(p.Id, p.Name, p.Price.Currency, p.Price.Amount, p.Sku));

            var products = await PagedList<ProductResponse>.CreateAsync(productResponsesQuery, request.Page, request.PageSize);

            return products;
        }
    }

}