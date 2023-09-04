using MediatR;

namespace Online.Shopping.Application.Products.Get
{
    public record GetProductsQuery(string SearchTerm, int Page, int PageSize) 
        : IRequest<PagedList<ProductResponse>>;
}
