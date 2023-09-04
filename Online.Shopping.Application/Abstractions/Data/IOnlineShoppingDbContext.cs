using Microsoft.EntityFrameworkCore;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Abstractions.Data
{
    public interface IOnlineShoppingDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
