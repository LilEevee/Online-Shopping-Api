using Online.Shopping.Domain.Products;
using Online.Shopping.Persistence;

namespace Online.Shopping.Presentation.Persistence
{
    internal sealed class ProductRepository : Repository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(OnlineShoppingDbContext onlineShoppingDbContext) : base(onlineShoppingDbContext)
        {
        }

        public Task<Product> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
