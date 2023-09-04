namespace Online.Shopping.Domain.Products
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        Task<Product?> GetByIdAsync(ProductId productId);
        void Update(Product product);
    }
}
