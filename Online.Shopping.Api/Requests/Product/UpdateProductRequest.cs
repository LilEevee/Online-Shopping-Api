namespace Online.Shopping.Api.Requests.Product
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Sku { get; set; }
    }
}
