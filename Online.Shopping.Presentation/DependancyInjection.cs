using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;
using Online.Shopping.Domain.Products;
using Online.Shopping.Persistence.Repositories;

namespace Online.Shopping.Persistence
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<OnlineShoppingDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("Database")),
                ServiceLifetime.Scoped);

            serviceCollection.AddScoped<IOnlineShoppingDbContext>(serviceProvider =>
                serviceProvider.GetRequiredService<OnlineShoppingDbContext>());

            serviceCollection.AddScoped<IUnitOfWork>(serviceProvider =>
                serviceProvider.GetRequiredService<OnlineShoppingDbContext>());

            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<ICartRepository, CartRepository>();

            return serviceCollection;
        }
    }
}
