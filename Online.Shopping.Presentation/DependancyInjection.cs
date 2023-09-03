using Microsoft.Extensions.DependencyInjection;

namespace Online.Shopping.Presentation
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
