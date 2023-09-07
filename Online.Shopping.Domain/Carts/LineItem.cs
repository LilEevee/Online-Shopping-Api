using Online.Shopping.Domain.Products;

namespace Online.Shopping.Domain.Carts
{
    public class LineItem
    {
        internal LineItem(LineItemId lineItemId, CartId cartId, ProductId productId, Price price)
        {
            LineItemId = lineItemId;
            CartId = cartId;
            ProductId = productId;
            Price = price;
        }

        private LineItem()
        {
        }

        public LineItemId LineItemId { get; private set; }

        public CartId CartId { get; private set; }

        public ProductId ProductId { get; private set; }

        public Price Price { get; private set; }
    }
}