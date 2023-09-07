namespace Online.Shopping.Domain.Carts
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(CartId id);

        void Add(Cart cart);
    }
}
