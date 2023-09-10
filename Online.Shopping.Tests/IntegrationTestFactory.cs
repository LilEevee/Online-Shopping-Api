using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online.Shopping.Persistence;
using Testcontainers.MsSql;

namespace Online.Shopping.Tests
{
    public class IntegrationTestFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _msSqlContainer;

        public IntegrationTestFactory()
        {
            _msSqlContainer = new MsSqlBuilder().Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<OnlineShoppingDbContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<OnlineShoppingDbContext>(options =>
                {
                    options.UseSqlServer(_msSqlContainer.GetConnectionString());
                });
            });
        }

        public Task InitializeAsync()
        {
            return _msSqlContainer.StartAsync();
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return _msSqlContainer.StopAsync();
        }
    }
}
