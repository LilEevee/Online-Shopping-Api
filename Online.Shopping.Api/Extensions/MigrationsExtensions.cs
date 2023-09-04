using Microsoft.EntityFrameworkCore;
using Online.Shopping.Persistence;

namespace Online.Shopping.Api.Extensions
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var onlineShoppingDbContext = scope.ServiceProvider.GetRequiredService<OnlineShoppingDbContext>();

            onlineShoppingDbContext.Database.Migrate();
        }
    }
}
