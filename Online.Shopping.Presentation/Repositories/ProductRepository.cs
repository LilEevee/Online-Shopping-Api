using Online.Shopping.Domain.Products;

namespace Online.Shopping.Persistence
{
    internal sealed class ProductRepository : Repository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(OnlineShoppingDbContext onlineShoppingDbContext) : base(onlineShoppingDbContext)
        {
        }
    }
}
