namespace Online.Shopping.Domain.Carts
{
    public sealed class CartNotFoundException : Exception
    {
        public CartNotFoundException(CartId cartId) : base($"Could not find a cart with the ID that has been supplied, ID : {cartId.Value}")
        { }
    }
}
