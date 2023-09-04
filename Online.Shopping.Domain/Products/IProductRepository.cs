namespace Online.Shopping.Domain.Products
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> GetAllAsync();
        void Update(Product product);
    }
}
