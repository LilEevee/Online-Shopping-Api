using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Domain.Carts
{
    public class LineItem
    {
        internal LineItem(LineItemId lineItemId, CartId cartId, ProductId productId, int price)
        {
            LineItemId = lineItemId;
            CartId = cartId;
            ProductId = productId;
            Quantity = price;
        }

        private LineItem()
        {
        }

        public LineItemId LineItemId { get; private set; }

        public CartId CartId { get; private set; }

        public ProductId ProductId { get; private set; }

        public int Quantity { get; private set; }
    }
}