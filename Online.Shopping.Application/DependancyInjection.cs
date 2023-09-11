using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Online.Shopping.Application.Abstractions;
using Online.Shopping.Application.Customers.Create;

namespace Online.Shopping.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(DependancyInjection).Assembly );
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            serviceCollection.AddValidatorsFromAssembly(typeof(CreateCustomerCommandValidator).Assembly);

            return serviceCollection;
        }
    }
}
