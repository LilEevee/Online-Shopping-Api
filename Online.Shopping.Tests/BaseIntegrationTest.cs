using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Online.Shopping.Persistence;

namespace Online.Shopping.Tests
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly OnlineShoppingDbContext _dbContext;

        protected BaseIntegrationTest(IntegrationTestFactory integrationTestFactory)
        {
            _scope = integrationTestFactory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            _dbContext = _scope.ServiceProvider.GetRequiredService<OnlineShoppingDbContext>();
        }
    }
}
