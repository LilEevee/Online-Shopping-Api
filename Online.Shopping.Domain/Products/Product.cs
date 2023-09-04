namespace Online.Shopping.Domain.Products
{
    public class Product : Entity<ProductId>
    {
        private Product()
        {
        }

        public Product(ProductId productId, string name, decimal price, int sku) : base(productId)
        {
            Name = name;
            Price = price;
            Sku = sku;
        }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Sku { get; private set; }
        public void Update(string name, decimal price, int sku)
        {
            Name = name;
            Price = price;
            Sku = sku;
        }
    }
}
