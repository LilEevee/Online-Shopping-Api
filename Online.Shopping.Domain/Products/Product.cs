using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Domain.Products
{
    public class Product : Entity<ProductId>
    {
        private Product()
        {
        }

        public Product(ProductId productId, string name, string description, Price price,  int sku) : base(productId)
        {
            Name = name;
            Description = Description;
            Price = price;
            Sku = sku;
        }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty; 
        public Price Price { get; private set; }
        public int Sku { get; private set; }
        public void Update(string name, string description, Price price, int sku)
        {
            Name = name;
            Description = description;
            Price = price;
            Sku = sku;
        }
    }
}
