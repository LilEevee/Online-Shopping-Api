using Microsoft.EntityFrameworkCore;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Abstractions.Data
{
    public interface IOnlineShoppingDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<LineItem> LineItems { get; set; }
    }
}
