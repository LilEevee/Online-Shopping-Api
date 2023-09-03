using Microsoft.Extensions.DependencyInjection;

namespace Online.Shopping.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
