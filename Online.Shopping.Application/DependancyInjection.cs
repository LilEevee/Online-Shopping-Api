using Microsoft.Extensions.DependencyInjection;

namespace Online.Shopping.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(configuration => 
                configuration.RegisterServicesFromAssemblies(typeof(DependancyInjection).Assembly));

            return serviceCollection;
        }
    }
}
