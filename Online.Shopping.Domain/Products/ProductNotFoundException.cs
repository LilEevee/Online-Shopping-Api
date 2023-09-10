namespace Online.Shopping.Domain.Products
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(ProductId productId) : base($"Could not find a product with the ID that has been supplied, ID : {productId.Value}")
        { }
    }
}
