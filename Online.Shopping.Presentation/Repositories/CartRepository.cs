using Microsoft.EntityFrameworkCore;
using Online.Shopping.Domain.Carts;

namespace Online.Shopping.Persistence.Repositories;

internal sealed class CartRepository : Repository<Cart, CartId>, ICartRepository
{
    public CartRepository(OnlineShoppingDbContext onlineShoppingDbContext)
        : base(onlineShoppingDbContext)
    {
    }

    public override Task<Cart?> GetByIdAsync(CartId id)
    {
        return _OnlineShoppingDbContext.Carts
            .Include(o => o.LineItems)
            .SingleOrDefaultAsync(o => o.Id == id);
    }
}
